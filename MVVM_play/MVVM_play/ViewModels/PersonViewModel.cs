﻿using CommunityToolkit.Mvvm.ComponentModel;
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

    public RelayCommand EditPersonCommand { get; }
    public RelayCommand DeletePersonCommand { get; }
    public RelayCommand ViewDetailsCommand { get; }

    public PersonViewModel()
    {
        // Sample data
        People = new ObservableCollection<Person>
        {
            new("Alice", 25),
            new("Bob", 30),
            new("Charlie", 35),
            new Person("David", 40),
            new Person("Eve", 45),
            new Person("Frank", 50),
            new Person("Grace", 55),
            new Person("Hank", 60),
            new Person("Ivy", 65),
            new Person("Jack", 70)

        };

        SelectedPerson = People[0];  // Default selection

        EditPersonCommand = new RelayCommand(EditPerson, CanEdit);
        DeletePersonCommand = new RelayCommand(DeletePerson, CanDelete);
        ViewDetailsCommand = new RelayCommand(ViewDetails, CanViewDetails);
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
