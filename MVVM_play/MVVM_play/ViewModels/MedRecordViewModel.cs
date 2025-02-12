using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MVVM_play.ViewModels;

public partial class MedRecordViewModel : ObservableObject
{
    private int _medicationId;
    public int MedicationId
    {
        get => _medicationId;
        set => SetProperty(ref _medicationId, value);
    }

    private string _medicationName;
    public string MedicationName
    {
        get => _medicationName;
        set => SetProperty(ref _medicationName, value);
    }

    private string _dosage;
    public string Dosage
    {
        get => _dosage;
        set => SetProperty(ref _dosage, value);
    }

    private string _route;
    public string Route
    {
        get => _route;
        set => SetProperty(ref _route, value);
    }

    private string _frequency;
    public string Frequency
    {
        get => _frequency;
        set => SetProperty(ref _frequency, value);
    }

    private string _status;
    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public ObservableCollection<AdminRecordViewModel> AdminRecords { get; }

    public MedRecordViewModel()
    {
        AdminRecords = new ObservableCollection<AdminRecordViewModel>();
    }
}
