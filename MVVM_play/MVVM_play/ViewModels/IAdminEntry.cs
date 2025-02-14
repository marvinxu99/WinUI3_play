using System;

namespace MVVM_play.ViewModels
{
    public interface IMedAdminEntry
    {
        long MedicationId { get; set; }
        DateTime? ScheduledTime { get; set; }

    }
}
