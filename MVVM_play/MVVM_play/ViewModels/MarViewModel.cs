using CommunityToolkit.Mvvm.ComponentModel;
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

    private string _patientName;
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

    public ObservableCollection<MedRecordViewModel> Medications { get; } = new();
    public ObservableCollection<string> TimeSlots { get; } = new();

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
            foreach (var record in med.AdminRecords)
            {
                // Format each administration time as "dd-MMM HH:mm".
                string slot = record.AdministrationTime.ToString("dd-MMM HH:mm", CultureInfo.InvariantCulture);
                timeSlotSet.Add(slot);
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
        PatientId = 1;
        PatientName = "John Doe";
        DateOfBirth = new DateTime(1990, 5, 14);
        RoomNumber = "101B";
        Allergies = "Penicillin";

        Medications.Add(new MedRecordViewModel
        {
            MedicationId = 1,
            MedicationName = "Ibuprofen",
            Dosage = "200mg",
            Route = "Oral",
            Frequency = "BID",
            Status = "Scheduled",
            AdminRecords = new ObservableCollection<AdminRecordViewModel>
        {
            new AdminRecordViewModel { AdminRecordId = 1, AdministrationTime = DateTime.Now.AddHours(-6), AdministeredBy = "Nurse Jane", Notes = "Taken with water", WasAdministered = true },
            new AdminRecordViewModel { AdminRecordId = 2, AdministrationTime = DateTime.Now.AddHours(-2), AdministeredBy = "", Notes = "", WasAdministered = false }, // Missed dose
            new AdminRecordViewModel { AdminRecordId = 3, AdministrationTime = DateTime.Now.AddHours(2), AdministeredBy = "", Notes = "", WasAdministered = false }, // Upcoming
            new AdminRecordViewModel { AdminRecordId = 3, AdministrationTime = DateTime.Now.AddHours(4), AdministeredBy = "", Notes = "", WasAdministered = false }, // Upcoming
            new AdminRecordViewModel { AdminRecordId = 3, AdministrationTime = DateTime.Now.AddHours(6), AdministeredBy = "", Notes = "", WasAdministered = false }, // Upcoming
        }
        });

        Medications.Add(new MedRecordViewModel
        {
            MedicationId = 2,
            MedicationName = "Amoxicillin",
            Dosage = "500mg",
            Route = "Oral",
            Frequency = "TID",
            Status = "Scheduled",
            AdminRecords = new ObservableCollection<AdminRecordViewModel>
        {
            new AdminRecordViewModel { AdminRecordId = 4, AdministrationTime = DateTime.Now.AddHours(-8), AdministeredBy = "Nurse Paul", Notes = "Taken with food", WasAdministered = true },
            new AdminRecordViewModel { AdminRecordId = 5, AdministrationTime = DateTime.Now.AddHours(-4), AdministeredBy = "Nurse Paul", Notes = "Taken", WasAdministered = true },
            new AdminRecordViewModel { AdminRecordId = 6, AdministrationTime = DateTime.Now.AddHours(4), AdministeredBy = "", Notes = "", WasAdministered = false }, // Pending
            new AdminRecordViewModel { AdminRecordId = 6, AdministrationTime = DateTime.Now.AddHours(8), AdministeredBy = "", Notes = "", WasAdministered = false }, // Pending
        }
        });

        Medications.Add(new MedRecordViewModel
        {
            MedicationId = 3,
            MedicationName = "Insulin",
            Dosage = "10 units",
            Route = "Subcutaneous",
            Frequency = "AC Meals",
            Status = "PRN",
            AdminRecords = new ObservableCollection<AdminRecordViewModel>
        {
            new AdminRecordViewModel { AdminRecordId = 7, AdministrationTime = DateTime.Now.AddHours(-3), AdministeredBy = "Nurse Sarah", Notes = "Pre-breakfast", WasAdministered = true },
            new AdminRecordViewModel { AdminRecordId = 8, AdministrationTime = DateTime.Now.AddHours(1), AdministeredBy = "", Notes = "", WasAdministered = false } // Upcoming
        }
        });
    }
}
