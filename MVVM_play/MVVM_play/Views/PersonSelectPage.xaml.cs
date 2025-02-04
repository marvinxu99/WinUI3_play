using Microsoft.UI.Xaml.Controls;
using MVVM_play.Models;
using MVVM_play.ViewModels;
using System;

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

        // ?? Subscribe to event for showing details
        ViewModel.ShowDetailsRequested += ShowPersonDetails;
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
}