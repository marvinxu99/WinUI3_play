using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_play.Models;
using MVVM_play.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MVVM_play.ViewModels;

public partial class UserViewModel : ObservableObject
{
    private readonly UserService _userService;

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

    public UserViewModel(UserService userService)
    {
        _userService = userService;
        _ = LoadUsersAsync();

        LoadUsersCommand = new AsyncRelayCommand(LoadUsersAsync);
        AddUserCommand = new AsyncRelayCommand(AddUser);
        UpdateUserCommand = new AsyncRelayCommand(UpdateUser);
        DeleteUserCommand = new AsyncRelayCommand(DeleteUser);
    }

    // Load users from the database
    private async Task LoadUsersAsync()
    {
        Users.Clear();
        var users = await _userService.GetAllUsersAsync();
        foreach (var user in users)
        {
            Users.Add(user);
        }
        //Users = new ObservableCollection<User>(users);
        //OnPropertyChanged(nameof(Users));
    }

    // Add a new user
    private async Task AddUser()
    {
        var newUser = new User { Name = "New User", Age = 20, City = "Unknown" };
        await _userService.AddUserAsync(newUser);
        await LoadUsersAsync();  // Refresh list
    }

    // Update the selected user
    private async Task UpdateUser()
    {
        if (SelectedUser != null)
        {
            await _userService.UpdateUserAsync(SelectedUser);
            await LoadUsersAsync();  // Refresh list
        }
    }

    // Delete the selected user
    private async Task DeleteUser()
    {
        if (SelectedUser != null)
        {
            await _userService.DeleteUserAsync(SelectedUser);
            await LoadUsersAsync();  // Refresh list
        }
    }

}
