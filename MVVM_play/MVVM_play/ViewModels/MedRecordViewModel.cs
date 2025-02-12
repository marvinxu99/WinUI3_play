using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace MVVM_play.ViewModels;

public partial class MedRecordViewModel : ObservableObject
{
    private int _medicationId = 0;
    public int MedicationId
    {
        get => _medicationId;
        set => SetProperty(ref _medicationId, value);
    }

    private string _medicationName = null!;
    public string MedicationName
    {
        get => _medicationName;
        set => SetProperty(ref _medicationName, value);
    }

    private string _dosage = null!;
    public string Dosage
    {
        get => _dosage;
        set => SetProperty(ref _dosage, value);
    }

    private string _route = null!;
    public string Route
    {
        get => _route;
        set => SetProperty(ref _route, value);
    }

    private string _frequency = null!;
    public string Frequency
    {
        get => _frequency;
        set => SetProperty(ref _frequency, value);
    }

    private string _status = null!;
    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public ObservableCollection<AdminRecordViewModel> AdminRecords { get; set; }

    public MedRecordViewModel()
    {
        AdminRecords = [];
    }

    // Indexer: given a time-slot string, return the matching AdminRecordViewModel (or null)
    public AdminRecordViewModel? this[string timeSlot] => AdminRecords.FirstOrDefault(r =>
            r.AdministrationTime.ToString("dd-MMM HH:mm", CultureInfo.InvariantCulture) == timeSlot);
}
