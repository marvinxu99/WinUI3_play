using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using MVVM_play.Models;
using MVVM_play.ViewModels;
using System;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class PersonSelectPage : Page
{
    private PersonViewModel ViewModel { get; }

    public PersonSelectPage()
    {
        this.InitializeComponent();
        ViewModel = new PersonViewModel();  // Create ViewModel instance
        DataContext = ViewModel;            // Assign DataContext

        // Handle selection changed event after UI is loaded
        Loaded += (s, e) =>
        {
            MyListBox.SelectionChanged += MyListBox_SelectionChanged;
            MyDataGrid.SelectionChanged += MyDataGrid_SelectionChanged;
        };

        // Subscribe to event for showing details
        ViewModel.ShowDetailsRequested += ShowPersonDetails;
        ViewModel.AddPersonRequested += AddPerson;
    }

    private async void ShowPersonDetails(Person person)
    {
        ContentDialog detailsDialog = new()
        {
            Title = "Person Details",
            Content = $"Name: {person.Name}\nAge: {person.Age}",
            CloseButtonText = "Close",
            XamlRoot = this.XamlRoot
        };

        await detailsDialog.ShowAsync();
    }

    private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MyListBox.SelectedItem != null)
        {
            MyListBox.ScrollIntoView(MyListBox.SelectedItem);
        }
    }

    private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MyDataGrid.SelectedItem != null)
        {
            MyDataGrid.ScrollIntoView(MyDataGrid.SelectedItem, null);
        }
    }

    private async void AddPerson()
    {
        ContentDialog dialog = new()
        {
            Title = "Add New Person",
            PrimaryButtonText = "Add",
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            XamlRoot = this.XamlRoot                  // Required for WinUI 3
        };

        // Create input fields
        StackPanel panel = new();

        TextBox nameBox = new() { PlaceholderText = "Enter Name" };
        TextBox ageBox = new()
        {
            PlaceholderText = "Enter Age",
            InputScope = new InputScope { Names = { new InputScopeName(InputScopeNameValue.Number) } }
        };

        panel.Children.Add(nameBox);
        panel.Children.Add(ageBox);

        dialog.Content = panel;

        if (await dialog.ShowAsync() == ContentDialogResult.Primary)
        {
            string name = nameBox.Text;
            int age = int.TryParse(ageBox.Text, out int parsedAge) ? parsedAge : 0;

            if (!string.IsNullOrEmpty(name) && age > 0)
            {
                ViewModel.People.Add(new Person(name, age)); // Add to ViewModel
                ViewModel.SelectedPerson = ViewModel.People[^1]; // Select new person
                Debug.WriteLine($"Added: {name}");
            }
        }
    }
}