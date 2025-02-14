using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using MVVM_play.ViewModels;
using System;

namespace MVVM_play.Controls
{
    public sealed partial class AdminRecordCell : UserControl
    {
        public AdminRecordCell()
        {
            this.InitializeComponent();
            // Update whenever DataContext changes.
            this.DataContextChanged += AdminRecordCell_DataContextChanged;
        }

        // DependencyProperty to receive the time-slot value.
        public string TimeSlot
        {
            get { return (string)GetValue(TimeSlotProperty); }
            set { SetValue(TimeSlotProperty, value); }
        }

        public static readonly DependencyProperty TimeSlotProperty =
            DependencyProperty.Register("TimeSlot", typeof(string), typeof(AdminRecordCell), new PropertyMetadata(null, OnTimeSlotChanged));

        private static void OnTimeSlotChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as AdminRecordCell)?.UpdateContent();
        }

        private void AdminRecordCell_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            UpdateContent();
        }

        private void UpdateContent()
        {
            // Ensure both DataContext and TimeSlot are set.
            if (DataContext is MedRecordViewModel medRecord && !string.IsNullOrEmpty(TimeSlot))
            {
                // Use the indexer from MedRecordViewModel to get the admin entry for this time slot.
                var entry = medRecord[TimeSlot];
                if (entry != null)
                {
                    // Determine the time to display: if the entry is a documented result, use AdministrationTime;
                    // otherwise, for a pending task, use ScheduledTime.
                    DateTime displayTime;
                    if (entry is AdminResultViewModel result)
                    {
                        displayTime = result.AdministrationTime;
                    }
                    else if (entry is AdminTaskViewModel task)
                    {
                        displayTime = task.ScheduledTime ?? DateTime.MinValue;
                    }
                    else
                    {
                        displayTime = DateTime.MinValue;
                    }
                    TimeTextBlock.Text = displayTime.ToString("dd-MMM HH:mm");

                    // Set background color:
                    if (entry is AdminResultViewModel documented)
                    {
                        CellBorder.Background = new SolidColorBrush(Colors.LightBlue);
                    }
                    else if (entry is AdminTaskViewModel)
                    {
                        // For pending tasks, use LightGreen.
                        //CellBorder.Background = new SolidColorBrush(Colors.LightGreen);

                        // For undocumented results (if any), show red if the administration time is old, else light gray.
                        CellBorder.Background = entry.ScheduledTime < DateTime.Now.AddHours(-1)
                            ? new SolidColorBrush(Colors.Red)
                            : new SolidColorBrush(Colors.LightGray);

                    }
                }
                else
                {
                    TimeTextBlock.Text = string.Empty;
                    CellBorder.Background = new SolidColorBrush(Colors.Transparent);
                }
            }
            else
            {
                TimeTextBlock.Text = string.Empty;
                CellBorder.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private async void CellBorder_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DoubleTapped event fired.");

            // Ensure DataContext is a MedRecordViewModel and a TimeSlot is set.
            if (DataContext is MedRecordViewModel medRecord && !string.IsNullOrEmpty(TimeSlot))
            {
                var entry = medRecord[TimeSlot];
                // Only allow editing for pending tasks.
                if (entry != null && entry is AdminTaskViewModel pendingTask)
                {
                    var dialog = new UpdateAdminRecordDialog();

                    // Set the XamlRoot so the dialog can render.
                    dialog.XamlRoot = this.XamlRoot;

                    // Pre-populate the dialog fields with the task's data.
                    dialog.AdminTimePicker.Date = pendingTask.ScheduledTime ?? DateTime.Now;
                    dialog.ActualDoseTextBox.Text = pendingTask.Dose;
                    dialog.NurseNameTextBox.Text = ""; // Optionally pre-populate if you have a default.

                    var result = await dialog.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        // Create a new documented result based on the data entered.
                        var newResult = new AdminResultViewModel
                        {
                            MedicationId = pendingTask.MedicationId,
                            ScheduledTime = pendingTask.ScheduledTime,
                            Dose = pendingTask.Dose,
                            AdministrationTime = dialog.AdminTimePicker.Date.DateTime,
                            ActualDose = dialog.ActualDoseTextBox.Text,
                            AdministeredBy = dialog.NurseNameTextBox.Text,
                            Notes = pendingTask.Notes
                        };

                        // Remove the task and add the new result.
                        medRecord.AdminTasks.Remove(pendingTask);
                        medRecord.AdminResults.Add(newResult);

                        // Refresh the cell's display.
                        UpdateContent();
                    }
                }
            }
        }
    }
}
