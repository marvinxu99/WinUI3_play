using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using MVVM_play.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MVVM_play.ViewModels;

//class PersonViewModel : INotifyPropertyChanged   // When not using MVVM package
internal partial class PersonViewModel : ObservableObject
{
    private Person _selectedPerson = null!;

    public ObservableCollection<Person> People { get; set; }

    public Person SelectedPerson
    {
        get => _selectedPerson;
        set => SetProperty(ref _selectedPerson, value);
    }

    public Action<Person>? ShowDetailsRequested { get; set; }  // UI event (Handled in View)
    public Action? AddPersonRequested { get; set; }

    public RelayCommand EditPersonCommand { get; }
    public RelayCommand DeletePersonCommand { get; }
    public RelayCommand ViewDetailsCommand { get; }
    public RelayCommand AddPersonCommand { get; }

    public PersonViewModel()
    {
        // Sample data
        People = new ObservableCollection<Person>
        {
            new("Alice", 25),
            new("Bob", 30),
            new("Charlie", 35),
            new("David", 40),
            new("Eve", 45),
            new("Frank", 50),
            new("Grace", 55),
            new("Hank", 60),
            new("Ivy", 65),
            new("Jack", 70)
        };

        SelectedPerson = People[0];  // Default selection

        EditPersonCommand = new RelayCommand(EditPerson, CanEdit);
        DeletePersonCommand = new RelayCommand(DeletePerson, CanDelete);
        ViewDetailsCommand = new RelayCommand(ViewDetails, CanViewDetails);
        AddPersonCommand = new RelayCommand(() => AddPersonRequested?.Invoke()); ;
    }


    public void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("Selected Changed");
    }

    public void MyDataGrid_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        Debug.WriteLine("key pressed!");
    }
    public void HandleKeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            // Handle Enter key
            Debug.WriteLine("Enter key pressed!");
        }
    }

    private void EditPerson()
    {
        Debug.WriteLine($"Editing {SelectedPerson?.Name}");
    }

    private void DeletePerson()
    {
        if (SelectedPerson != null)
        {
            People.Remove(SelectedPerson);
            Debug.WriteLine($"Deleted {SelectedPerson.Name}");
        }
    }

    private void AddPerson()
    {
        var newPerson = new Person("New Person", 20);  // Create a new person
        People.Add(newPerson);
        SelectedPerson = newPerson;  // Select the newly added person
        Debug.WriteLine($"Added: {newPerson.Name}");
    }

    private void ViewDetails()
    {
        if (SelectedPerson != null)
        {
            ShowDetailsRequested?.Invoke(SelectedPerson); // Notify View to show the dialog
        }

    }

    private bool CanEdit() => SelectedPerson != null;
    private bool CanDelete() => SelectedPerson != null;
    private bool CanViewDetails() => SelectedPerson != null;

}
