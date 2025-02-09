using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Models;
using MVVM_play.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVVM_play.ViewModels;


internal partial class UserMergedViewModel : ObservableObject
{
    private readonly DatabaseContext _dbContext;
    private UserWithProfile? _selectedUser;
    private readonly Dictionary<int, Dictionary<string, object>> _modifiedUserCells = [];
    private readonly Dictionary<int, Dictionary<string, object>> _modifiedProfileCells = [];
    private readonly LoggingService _logger;

    public UserWithProfile? SelectedUser
    {
        get => _selectedUser;
        set
        {
            SetProperty(ref _selectedUser, value);

            // Notify commands to re-evaluate CanExecute()
            AddUserProfileCommand?.NotifyCanExecuteChanged();
            UpdateUserProfileCommand?.NotifyCanExecuteChanged();
            SignChangesCommand?.NotifyCanExecuteChanged();
        }
    }

    public ObservableCollection<UserWithProfile> UsersWithProfiles { get; set; } = [];

    // Define events to request dialogs from the View
    public event Action<UserWithProfile>? RequestAddProfileDialog;
    public event Action<UserWithProfile>? RequestUpdateProfileDialog;
    public event Action? RequestShowSuccessDialog;  // Event for notifying View to show success dialog


    public IRelayCommand AddUserProfileCommand { get; }
    public IRelayCommand UpdateUserProfileCommand { get; }
    public IRelayCommand SignChangesCommand { get; }

    public UserMergedViewModel(DatabaseContext dbContext, LoggingService logger)
    {
        _dbContext = dbContext;
        _logger = logger;

        // Initialize Commands
        AddUserProfileCommand = new RelayCommand(() => RequestAddProfileDialog?.Invoke(SelectedUser!), CanAdd);
        UpdateUserProfileCommand = new RelayCommand(() => RequestUpdateProfileDialog?.Invoke(SelectedUser!), CanEdit);
        SignChangesCommand = new RelayCommand(SignChanges, CanSign);

        //LoadUsersWithProfilesAsync().ConfigureAwait(false);
        _ = LoadUsersWithProfilesAsync();
    }

    public async Task LoadUsersWithProfilesAsync()
    {
        //var usersWithProfiles = await _dbContext.Users
        //    .Include(u => u.UserProfile)  // Load related UserProfile data
        //    .Select(u => new UserWithProfileViewModel(u, u.UserProfile))
        //    .ToListAsync();

        var usersWithProfiles = await _dbContext.Users
        .GroupJoin(
            _dbContext.UserProfiles, // Join with UserProfiles table
            user => user.Id,         // Primary Key in Users table
            profile => profile.UserId, // Foreign Key in UserProfiles
            (user, profiles) => new { user, profile = profiles.FirstOrDefault() } // LEFT JOIN
        )
        .Select(up => new UserWithProfile(up.user, up.profile))
        .ToListAsync();

        //UsersWithProfiles.Clear();
        //foreach (var item in usersWithProfiles)
        //    UsersWithProfiles.Add(item);
        /*******************************************
         * Binding in XAML does not detect individual property changes 
         * inside ObservableCollection unless the whole list is replaced.
         **********************************************************************/
        UsersWithProfiles = new ObservableCollection<UserWithProfile>(usersWithProfiles);
        OnPropertyChanged(nameof(UsersWithProfiles));

        // Ensure the selection remains after reload
        if (SelectedUser == null || !UsersWithProfiles.Any(u => u.Id == SelectedUser.Id))
        {
            SelectedUser = UsersWithProfiles.FirstOrDefault();
        }

        // Notify SignChangesCommand if it can execute
        SignChangesCommand.NotifyCanExecuteChanged();

        _logger.Information("UI Refreshed in LoadUsersWithProfilesAsync() in ViewModel.");

    }

    // Receive user input from View and save new profile
    public async Task SaveNewUserProfileAsync(int userId, string gender, string primaryAddress)
    {
        var newProfile = new UserProfile
        {
            UserId = userId,
            Gender = gender,
            PrimaryAddress = primaryAddress
        };

        _dbContext.UserProfiles.Add(newProfile);
        await _dbContext.SaveChangesAsync();

        Debug.WriteLine($"User Profile Added: {gender}, {primaryAddress}");
        await LoadUsersWithProfilesAsync(); // Refresh UI
    }

    // Receive user input from View and update profile
    public async Task SaveUpdatedUserProfileAsync(int userId, string gender, string primaryAddress)
    {
        var existingProfile = await _dbContext.UserProfiles.FirstAsync(up => up.UserId == userId);
        if (existingProfile != null)
        {
            existingProfile.Gender = gender;
            existingProfile.PrimaryAddress = primaryAddress;

            await _dbContext.SaveChangesAsync();
            Debug.WriteLine("User Profile Updated!");
            await LoadUsersWithProfilesAsync();
        }
    }

    private bool CanAdd() => SelectedUser != null && SelectedUser.UserProfileId == 0;

    private bool CanEdit() => SelectedUser != null && SelectedUser.UserProfileId > 0;

    public void DataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("Selected Changed");
        SelectedUser = (UserWithProfile?)e.AddedItems[0];

        // Notify commands to update based on new selection
        AddUserProfileCommand.NotifyCanExecuteChanged();
        UpdateUserProfileCommand.NotifyCanExecuteChanged();
        SignChangesCommand.NotifyCanExecuteChanged();
    }

    public void TrackCellChange(int userId, string columnName, object newValue)
    {
        if (IsUserColumn(columnName))
        {
            if (!_modifiedUserCells.TryGetValue(userId, out var cellChanges))
            {
                cellChanges = [];
                _modifiedUserCells[userId] = cellChanges;
            }

            //_modifiedCells[userId][columnName] = newValue;  TO AVOID DOUBLE LOOKUP
            cellChanges[columnName] = newValue;
        }
        else if (IsUserProfileColumn(columnName))
        {
            if (!_modifiedProfileCells.TryGetValue(userId, out var cellChanges))
            {
                cellChanges = [];
                _modifiedProfileCells[userId] = cellChanges;
            }

            //_modifiedCells[userId][columnName] = newValue;  TO AVOID DOUBLE LOOKUP
            cellChanges[columnName] = newValue;
        }

        // Notify SignCommand when changes are detected
        SignChangesCommand.NotifyCanExecuteChanged();
    }

    public async Task SaveChangesAsync()
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync(); // Ensure atomic updates

        try
        {
            // Update User table
            foreach (var row in _modifiedUserCells)
            {
                int userId = row.Key;
                var user = await _dbContext.Users.FindAsync(userId);

                if (user == null)
                    continue;       // Skip if user doesn't exist

                foreach (var column in row.Value)
                {
                    string propertyName = column.Key;
                    object newValue = column.Value;
                    PropertyInfo? property = user.GetType().GetProperty(propertyName);

                    if (property != null)
                    {
                        try
                        {
                            // Convert newValue to the correct type before setting it
                            object convertedValue = Convert.ChangeType(newValue, property.PropertyType);
                            property.SetValue(user, convertedValue);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error setting property '{propertyName}': {ex.Message}");
                        }
                    }
                }

            }

            // Update UserProfile table
            foreach (var row in _modifiedProfileCells)
            {
                int userId = row.Key;
                var profile = await _dbContext.UserProfiles.FirstOrDefaultAsync(up => up.UserId == userId);

                if (profile == null)
                {
                    profile = new UserProfile()
                    {
                        UserId = userId
                    };
                    _dbContext.UserProfiles.Add(profile);
                }

                foreach (var column in row.Value)
                {
                    string propertyName = column.Key;
                    object newValue = column.Value;
                    PropertyInfo? property = profile.GetType().GetProperty(propertyName);

                    if (property != null)
                    {
                        try
                        {
                            // Convert newValue to the correct type before setting it
                            object convertedValue = Convert.ChangeType(newValue, property.PropertyType);
                            property.SetValue(profile, convertedValue);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error setting property '{propertyName}': {ex.Message}");
                        }
                    }
                }
            }

            // Save changes to database
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            _modifiedUserCells.Clear();
            _modifiedProfileCells.Clear();

            // Refresh UI after saving
            await LoadUsersWithProfilesAsync();

            // Notify the View to show the success message
            RequestShowSuccessDialog?.Invoke();
            SignChangesCommand.NotifyCanExecuteChanged();  // Disable "Sign" button after save

        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Debug.WriteLine($"Transaction failed: {ex.Message}");
        }
    }

    private void SignChanges()
    {
        _ = SaveChangesAsync();
    }

    private bool CanSign()
    {
        return _modifiedUserCells.Count > 0 || _modifiedProfileCells.Count > 0; // Enable Sign button only if there are changes
    }

    private static readonly HashSet<string> UserColumns = ["Name", "Age", "City"];
    private static readonly HashSet<string> UserProfileColumns = ["Gender", "PrimaryAddress", "SecondaryAddress", "AvatarUrl"];

    private static bool IsUserColumn(string columnName) => UserColumns.Contains(columnName);
    private static bool IsUserProfileColumn(string columnName) => UserProfileColumns.Contains(columnName);
}
