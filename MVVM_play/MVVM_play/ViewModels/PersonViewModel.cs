using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_play.Models;
using System.Collections.ObjectModel;

namespace MVVM_play.ViewModels;

//class PersonViewModel : INotifyPropertyChanged   // When not using MVVM package
class PersonViewModel : ObservableObject
{
    private Person _selectedPerson = null!;

    public ObservableCollection<Person> People { get; set; }

    public Person SelectedPerson
    {
        get => _selectedPerson;
        set => SetProperty(ref _selectedPerson, value);
    }

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
    }

    // BELOW CODE needed when not using MVVM
    //public event PropertyChangedEventHandler? PropertyChanged;
    //protected void OnPropertyChanged(string propertyName)
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

}
