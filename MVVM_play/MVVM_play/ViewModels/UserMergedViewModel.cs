﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM_play.ViewModels;

internal class UserWithProfile
{
    public int Id { get; set; }  // User ID
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string? City { get; set; }

    // UserProfile fields
    public int UserProfileId { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string? PrimaryAddress { get; set; }
    public string? SecondaryAddress { get; set; }
    public string? AvatarUrl { get; set; }
    public DateTime? CreatedDateTime { get; set; }

    // Constructor to Map Data
    public UserWithProfile(Models.User user, UserProfile? profile)
    {
        Id = user.Id;
        Name = user.Name;
        Age = user.Age;
        City = user.City;

        if (profile != null)
        {
            UserProfileId = profile.Id;
            Gender = profile.Gender;
            PrimaryAddress = profile.PrimaryAddress;
            SecondaryAddress = profile.SecondaryAddress;
            AvatarUrl = profile.AvatarUrl;
            CreatedDateTime = profile.CreatedDateTime;
        }

    }

}

internal partial class UserMergedViewModel : ObservableObject
{
    private readonly DatabaseContext _dbContext;

    private UserWithProfile? _selectedUser;
    public UserWithProfile? SelectedUser
    {
        get => _selectedUser;
        set
        {
            SetProperty(ref _selectedUser, value);

            // Notify commands to re-evaluate CanExecute()
            AddUserProfileCommand?.NotifyCanExecuteChanged();
            UpdateUserProfileCommand?.NotifyCanExecuteChanged();
        }
    }

    public ObservableCollection<UserWithProfile> UsersWithProfiles { get; set; } = [];

    // Define events to request dialogs from the View
    public event Action<UserWithProfile>? RequestAddProfileDialog;
    public event Action<UserWithProfile>? RequestUpdateProfileDialog;

    public IRelayCommand AddUserProfileCommand { get; }
    public IRelayCommand UpdateUserProfileCommand { get; }

    public UserMergedViewModel()
    {
        _dbContext = new DatabaseContext();
        //LoadUsersWithProfilesAsync().ConfigureAwait(false);
        _ = LoadUsersWithProfilesAsync();

        // Initialize Commands
        AddUserProfileCommand = new RelayCommand(() => RequestAddProfileDialog?.Invoke(SelectedUser!), CanAdd);
        UpdateUserProfileCommand = new RelayCommand(() => RequestUpdateProfileDialog?.Invoke(SelectedUser!), CanEdit);
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
    }
}
