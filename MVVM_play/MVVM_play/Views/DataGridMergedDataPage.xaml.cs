using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.ViewModels;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class DataGridMergedDataPage : Page
{
    private UserMergedViewModel ViewModel { get; }

    public DataGridMergedDataPage()
    {
        this.InitializeComponent();
        ViewModel = new UserMergedViewModel();  // Create ViewModel instance
        DataContext = ViewModel;            // Assign DataContext

        // Subscribe to ViewModel events
        ViewModel.RequestAddProfileDialog += ShowAddProfileDialog;
        ViewModel.RequestUpdateProfileDialog += ShowUpdateProfileDialog;
        ViewModel.RequestShowSuccessDialog += ShowSaveSuccessDialog;
    }

    private async void ShowAddProfileDialog(UserWithProfile user)
    {
        if (user == null) return;

        ContentDialog dialog = new()
        {
            Title = $"Add Profile for {user.Name}",
            PrimaryButtonText = "Save",
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = this.XamlRoot                  // Required for WinUI 3
        };

        StackPanel panel = new();
        TextBox genderBox = new() { PlaceholderText = "Enter Gender" };
        TextBox addressBox = new() { PlaceholderText = "Enter Address" };

        panel.Children.Add(genderBox);
        panel.Children.Add(addressBox);
        dialog.Content = panel;

        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            string gender = genderBox.Text;
            string address = addressBox.Text;

            await ViewModel.SaveNewUserProfileAsync(user.Id, gender, address);
        }
    }

    private async void ShowUpdateProfileDialog(UserWithProfile user)
    {
        if (user == null) return;

        ContentDialog dialog = new()
        {
            Title = $"Update Profile for {user.Name}",
            PrimaryButtonText = "Save",
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = this.XamlRoot                  // Required for WinUI 3
        };

        StackPanel panel = new();
        TextBox genderBox = new() { Text = user.Gender };
        TextBox addressBox = new() { Text = user.PrimaryAddress };

        panel.Children.Add(genderBox);
        panel.Children.Add(addressBox);
        dialog.Content = panel;

        var result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            string gender = genderBox.Text;
            string address = addressBox.Text ?? "";

            await ViewModel.SaveUpdatedUserProfileAsync(user.Id, gender, address);
        }
    }

    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Row.DataContext is UserWithProfile user)
        {
            string? columnName = e.Column.Header.ToString();
            if (columnName != null)
            {
                TextBox? textBox = e.EditingElement as TextBox;
                object newValue = textBox?.Text ?? "";

                int userId = (int)e.Row.Tag;  // Get associated User ID from Row Tag

                ViewModel.TrackCellChange(userId, columnName, newValue);
            }
        }
    }

    private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        if (e.Row.DataContext is UserWithProfile user)
        {
            e.Row.Tag = user.Id;  // Store User ID in Row Tag
        }
    }

    private async void ShowSaveSuccessDialog()
    {
        ContentDialog successDialog = new()
        {
            Title = "Success",
            Content = "Changes saved successfully!",
            CloseButtonText = "OK",
            XamlRoot = this.XamlRoot
        };

        await successDialog.ShowAsync();
    }
}