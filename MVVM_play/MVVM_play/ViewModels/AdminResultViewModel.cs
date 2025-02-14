using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MVVM_play.ViewModels
{
    public class AdminResultViewModel : ObservableObject, IMedAdminEntry
    {
        public long MedicationId { get; set; }
        public DateTime? ScheduledTime { get; set; }

        // Additional properties and logic specific to documented results.
        private int _adminRecordId;
        public int AdminRecordId
        {
            get => _adminRecordId;
            set => SetProperty(ref _adminRecordId, value);
        }

        private DateTime _administrationTime;
        public DateTime AdministrationTime
        {
            get => _administrationTime;
            set => SetProperty(ref _administrationTime, value);
        }

        private string? _administeredBy;
        public string? AdministeredBy
        {
            get => _administeredBy;
            set => SetProperty(ref _administeredBy, value);
        }

        private string? _notes;
        public string? Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public string? Dose { get; set; }

        // New property for the actual dose
        private string? _actualDose;
        public string? ActualDose
        {
            get => _actualDose;
            set => SetProperty(ref _actualDose, value);
        }
    }
}
