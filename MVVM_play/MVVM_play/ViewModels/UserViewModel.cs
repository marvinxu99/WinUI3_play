using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_play.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MVVM_play.ViewModels;

internal partial class UserViewModel : ObservableObject
{
    private readonly DatabaseContext _dbContext = new();

    private User? _selectedUser; // Track selected user

    public ObservableCollection<User> Users { get; set; } = [];

    public User? SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    public IRelayCommand LoadUsersCommand { get; }
    public IRelayCommand AddUserCommand { get; }
    public IRelayCommand UpdateUserCommand { get; }
    public IRelayCommand DeleteUserCommand { get; }

    public UserViewModel()
    {
        _dbContext.InitializeDatabase();
        _ = LoadUsers();

        LoadUsersCommand = new AsyncRelayCommand(LoadUsers);
        AddUserCommand = new AsyncRelayCommand(AddUser);
        UpdateUserCommand = new AsyncRelayCommand(UpdateUser);
        DeleteUserCommand = new AsyncRelayCommand(DeleteUser);
    }

    // Load users from the database
    private async Task LoadUsers()
    {
        Users.Clear();
        var users = await _dbContext.GetUsersAsync();
        foreach (var user in users)
        {
            Users.Add(user);
        }
    }

    // Add a new user
    private async Task AddUser()
    {
        var newUser = new User { Name = "New User", Age = 20, City = "Unknown" };
        await _dbContext.AddUserAsync(newUser);
        await LoadUsers();  // Refresh list
    }

    // Update the selected user
    private async Task UpdateUser()
    {
        if (SelectedUser != null)
        {
            await _dbContext.UpdateUserAsync(SelectedUser);
            await LoadUsers();  // Refresh list
        }
    }

    // Delete the selected user
    private async Task DeleteUser()
    {
        if (SelectedUser != null)
        {
            await _dbContext.DeleteUserAsync(SelectedUser);
            await LoadUsers();  // Refresh list
        }
    }

}
