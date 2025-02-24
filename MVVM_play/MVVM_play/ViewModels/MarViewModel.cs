using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace MVVM_play.ViewModels;


public partial class MarViewModel : ObservableObject
{
    private int _patientId;
    public int PatientId
    {
        get => _patientId;
        set => SetProperty(ref _patientId, value);
    }

    private string _patientName = null!;
    public string PatientName
    {
        get => _patientName;
        set => SetProperty(ref _patientName, value);
    }

    private DateTime _dateOfBirth;
    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set => SetProperty(ref _dateOfBirth, value);
    }

    private string _roomNumber;
    public string RoomNumber
    {
        get => _roomNumber;
        set => SetProperty(ref _roomNumber, value);
    }

    private string _allergies;
    public string Allergies
    {
        get => _allergies;
        set => SetProperty(ref _allergies, value);
    }

    // Filters - Use manual properties for WinRT compatibility
    private bool _showScheduled = true;
    public bool ShowScheduled
    {
        get => _showScheduled;
        set => SetProperty(ref _showScheduled, value);
    }

    private bool _showPRN = true;
    public bool ShowPRN
    {
        get => _showPRN;
        set => SetProperty(ref _showPRN, value);
    }

    private bool _showContinuous = true;
    public bool ShowContinuous
    {
        get => _showContinuous;
        set => SetProperty(ref _showContinuous, value);
    }

    private bool _showFuture = true;
    public bool ShowFuture
    {
        get => _showFuture;
        set => SetProperty(ref _showFuture, value);
    }

    private bool _showDiscontinued = false;
    public bool ShowDiscontinued
    {
        get => _showDiscontinued;
        set => SetProperty(ref _showDiscontinued, value);
    }

    public ObservableCollection<MedRecordViewModel> Medications { get; } = [];

    public ObservableCollection<string> TimeSlots { get; } = [];

    public MarViewModel()
    {
        LoadMockData();
        GenerateTimeSlots();
    }

    private void GenerateTimeSlots()
    {
        // Use a HashSet to collect unique time slot strings from all admin records.
        var timeSlotSet = new HashSet<string>();

        foreach (var med in Medications)
        {
            // Combine AdminResults and AdminTasks (both implement IMedAdminEntry).
            var adminEntries = med.AdminResults.Cast<IMedAdminEntry>().Concat(med.AdminTasks);
            foreach (var entry in adminEntries)
            {
                if (entry.ScheduledTime.HasValue)
                {
                    string slot = entry.ScheduledTime.Value.ToString("dd-MMM HH:mm", CultureInfo.InvariantCulture);
                    timeSlotSet.Add(slot);
                }
            }
        }

        // Order the time slots reverse-chronologically.
        var orderedSlots = timeSlotSet
            .Select(ts => DateTime.ParseExact(ts, "dd-MMM HH:mm", CultureInfo.InvariantCulture))
            .OrderByDescending(dt => dt)
            .Select(dt => dt.ToString("dd-MMM HH:mm"));

        // Clear any existing slots and add the new ones.
        TimeSlots.Clear();
        foreach (var slot in orderedSlots)
        {
            TimeSlots.Add(slot);
        }
    }

    private void LoadMockData()
    {
        Medications.Clear(); // Prevent duplicates

        PatientId = 1;
        PatientName = "John Doe";
        DateOfBirth = new DateTime(1990, 5, 14);
        RoomNumber = "101B";
        Allergies = "Penicillin";

        // Medication 1: Ibuprofen with documented results only.
        Medications.Add(new MedRecordViewModel
        {
            MedicationId = 1,
            MedicationName = "Ibuprofen",
            Dosage = "200mg",
            Route = "Oral",
            Frequency = "BID",
            Status = "Scheduled",
            AdminResults = new ObservableCollection<AdminResultViewModel>
                {
                    new AdminResultViewModel { AdminRecordId = 1, AdministrationTime = DateTime.Now.AddHours(-6), AdministeredBy = "Nurse Jane", Notes = "", ScheduledTime = DateTime.Now.AddHours(-6), ActualDose = "100mg" },

                    new AdminResultViewModel { AdminRecordId = 2, AdministrationTime = DateTime.Now.AddHours(-2), AdministeredBy = "", Notes = "", ScheduledTime = DateTime.Now.AddHours(-2), ActualDose = "200mg" },
                },
            AdminTasks = new ObservableCollection<AdminTaskViewModel>
            {
                new AdminTaskViewModel { MedicationId = 1, ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(2)), Dose = "200mg", Notes = "Undocumented med task" },
                new AdminTaskViewModel { MedicationId = 1, ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(8)), Dose = "200mg", Notes = "Undocumented med task" },
                new AdminTaskViewModel { MedicationId = 1, ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(14)), Dose = "200mg", Notes = "Undocumented med task" },
            }
        });

        // Medication 2: Amoxicillin with both documented results and pending tasks.
        Medications.Add(new MedRecordViewModel
        {
            MedicationId = 2,
            MedicationName = "Amoxicillin",
            Dosage = "500mg",
            Route = "Oral",
            Frequency = "TID",
            Status = "Scheduled",
            AdminResults = new ObservableCollection<AdminResultViewModel>
                {
                    new AdminResultViewModel { AdminRecordId = 6, AdministrationTime = RoundToNearestHalfHour(DateTime.Now.AddHours(-8)), AdministeredBy = "Nurse Paul", Notes = "Taken with food", ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(-8)), ActualDose = "500mg" },
                    new AdminResultViewModel { AdminRecordId = 7, AdministrationTime = RoundToNearestHalfHour(DateTime.Now.AddHours(-4)), AdministeredBy = "Nurse Paul", Notes = "Taken", ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(-4)), ActualDose = "500mg" },
                    new AdminResultViewModel { AdminRecordId = 8, AdministrationTime = RoundToNearestHalfHour(DateTime.Now.AddHours(-1)), AdministeredBy = "", Notes = "Taken", ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(-1)), ActualDose = "500mg" }
                },
            AdminTasks = new ObservableCollection<AdminTaskViewModel>
                {
                    new AdminTaskViewModel { MedicationId = 2, ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(4)), Dose = "500mg", Notes = "Undocumented med task" },
                    new AdminTaskViewModel { MedicationId = 2, ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(8)), Dose = "500mg", Notes = "Undocumented med task" },
                    new AdminTaskViewModel { MedicationId = 2, ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(10)), Dose = "500mg", Notes = "Undocumented med task" }
                }
        });

        // Medication 3: Insulin with documented results only.
        Medications.Add(new MedRecordViewModel
        {
            MedicationId = 3,
            MedicationName = "Insulin",
            Dosage = "10 units",
            Route = "Subcutaneous",
            Frequency = "AC Meals",
            Status = "PRN",
            AdminResults = new ObservableCollection<AdminResultViewModel>
                {
                    new AdminResultViewModel { AdminRecordId = 9, AdministrationTime = DateTime.Now.AddHours(-6), AdministeredBy = "Nurse Sarah", Notes = "Pre-breakfast", ScheduledTime = DateTime.Now.AddHours(-6), ActualDose = "10 units" },

                new AdminResultViewModel { AdminRecordId = 10, AdministrationTime = DateTime.Now.AddHours(-3), AdministeredBy = "", Notes = "", ScheduledTime = DateTime.Now.AddHours(-3), ActualDose = "10 units" }
                },
            AdminTasks = new ObservableCollection<AdminTaskViewModel>
            {
                    new AdminTaskViewModel { MedicationId = 3, ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(-2)), Dose = "10 units", Notes = "Undocumented med task" },
                    new AdminTaskViewModel { MedicationId = 3, ScheduledTime = RoundToNearestHalfHour(DateTime.Now.AddHours(6)), Dose = "10 units", Notes = "Undocumented med task" }
            }
        });
    }

    public CollectionViewSource GroupedMedications()
    {
        //using MountainDbContext dbContext = new();
        // No ToListAsync() here, since we bail out of Entity Framework to do the Grouping.

        //IEnumerable<GroupInfoCollection<string, MedRecordViewModel>> query = Medications
        var query = Medications
                        //.OrderBy(m => m.Status)
                        .OrderByDescending(m => m.Status)
                        .GroupBy(m => m.Status, (key, list) => new GroupInfoCollection<string, MedRecordViewModel>(key, list));

        CollectionViewSource groupedItems = new()
        {
            IsSourceGrouped = true,
            Source = query
        };

        return groupedItems;
    }

    public class GroupInfoCollection<K, T> : IGrouping<K, T>
    {
        private readonly IEnumerable<T> _items;

        public GroupInfoCollection(K key, IEnumerable<T> items)
        {
            Key = key;
            _items = items;
        }

        public K Key { get; }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }

    public static DateTime RoundToNearestHalfHour(DateTime dt)
    {
        int minutes = dt.Minute;
        int remainder = minutes % 30;

        // If remainder < 15, round down; otherwise, round up
        if (remainder < 15)
            dt = dt.AddMinutes(-remainder);
        else
            dt = dt.AddMinutes(30 - remainder);

        return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, dt.Kind);
    }

}
