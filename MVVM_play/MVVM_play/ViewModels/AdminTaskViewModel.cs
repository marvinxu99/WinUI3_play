using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MVVM_play.ViewModels
{
    public class AdminTaskViewModel : ObservableObject, IMedAdminEntry
    {
        public long MedicationId { get; set; }
        public DateTime? ScheduledTime { get; set; }

        public string? Dose { get; set; }

        private string? _notes;
        public string? Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public bool IsMedResult { get; } = false;

    }


}
