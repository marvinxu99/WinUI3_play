using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

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

    private MedRecordViewModel? _selectedMedication;
    public MedRecordViewModel? SelectedMedication
    {
        get => _selectedMedication;
        set => SetProperty(ref _selectedMedication, value);
    }

    public ObservableCollection<MedRecordViewModel> Medications { get; }

    public IRelayCommand AddAdminRecordCommand { get; }

    public MarViewModel()
    {
        Medications = new ObservableCollection<MedRecordViewModel>();
        AddAdminRecordCommand = new RelayCommand(AddAdminRecord);
        LoadMockData();
    }

    private void LoadMockData()
    {
        PatientId = 1;
        PatientName = "John Doe";
        DateOfBirth = new DateTime(1990, 5, 14);
        RoomNumber = "101B";
        Allergies = "Penicillin";

        var medication = new MedRecordViewModel
        {
            MedicationId = 1,
            MedicationName = "Ibuprofen",
            Dosage = "200mg",
            Route = "Oral",
            Frequency = "BID",
            Status = "Scheduled"
        };

        medication.AdminRecords.Add(new AdminRecordViewModel
        {
            AdminRecordId = 1,
            AdministrationTime = DateTime.Now.AddHours(-2),
            AdministeredBy = "Nurse Jane",
            Notes = "Taken with water",
            WasAdministered = true
        });

        Medications.Add(medication);
        SelectedMedication = medication;
    }

    private void AddAdminRecord()
    {
        if (SelectedMedication != null)
        {
            SelectedMedication.AdminRecords.Add(new AdminRecordViewModel
            {
                AdminRecordId = SelectedMedication.AdminRecords.Count + 1,
                AdministrationTime = DateTime.Now,
                AdministeredBy = "Nurse Smith",
                Notes = "Given as per schedule",
                WasAdministered = true
            });
        }
    }
}
