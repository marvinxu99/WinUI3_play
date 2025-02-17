using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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

    private string _status = null!;   // Scheduled, PRN
    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public ObservableCollection<AdminResultViewModel> AdminResults { get; set; }
    public ObservableCollection<AdminTaskViewModel> AdminTasks { get; set; }

    public MedRecordViewModel()
    {
        AdminResults = [];
        AdminTasks = [];
    }

    // Combined enumerable of all admin entries (both results and tasks).
    public IEnumerable<IMedAdminEntry> AdminEntries =>
        (AdminResults ?? Enumerable.Empty<AdminResultViewModel>()).Cast<IMedAdminEntry>()
        .Concat(AdminTasks ?? Enumerable.Empty<AdminTaskViewModel>());


    // Indexer: given a time-slot string, return the matching admin entry (or null).
    public IMedAdminEntry? this[string timeSlot] =>
            AdminEntries.FirstOrDefault(r => r.ScheduledTime.HasValue &&
            r.ScheduledTime.Value.ToString("dd-MMM HH:mm", CultureInfo.InvariantCulture) == timeSlot);


    // Returns the pending admin entry from AdminTaskViewModel only.
    public IMedAdminEntry? PendingAdminEntry
    {
        get
        {
            // Only consider entries from AdminTaskViewModel as pending.
            var pendingEntries = AdminTasks;

            // Get the upcoming pending entry (scheduled for the future).
            var upcoming = pendingEntries
                .Where(r => r.ScheduledTime.HasValue && r.ScheduledTime.Value >= DateTime.Now)
                .OrderBy(r => r.ScheduledTime)
                .FirstOrDefault();
            if (upcoming != null)
                return upcoming;

            // Otherwise, return the most recent past pending entry.
            return pendingEntries
                .Where(r => r.ScheduledTime.HasValue && r.ScheduledTime.Value < DateTime.Now)
                .OrderByDescending(r => r.ScheduledTime)
                .FirstOrDefault();
        }
    }
}
