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
            this.SizeChanged += AdminRecordCell_SizeChanged;
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

        private void AdminRecordCell_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // If the current entry is an AdminResultViewModel, update its height to 50% of the cell's new height.
            if (DataContext is MedRecordViewModel medRecord && !string.IsNullOrEmpty(TimeSlot))
            {
                var entry = medRecord[TimeSlot];
                if (entry is AdminResultViewModel)
                {
                    AdminCell.Height = e.NewSize.Height * 0.3;
                }
                else if (entry is AdminTaskViewModel)
                {
                    // For pending tasks, use 80% of the new height.
                    AdminCell.Height = e.NewSize.Height * 0.8;
                }
            }
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
                    // Set background color & text
                    if (entry is AdminResultViewModel documented)
                    {
                        // For documented results, position the border at the bottom and fill only 50% of the cell height.
                        AdminCell.VerticalAlignment = VerticalAlignment.Bottom;

                        // If ActualHeight is available, set height to 50%; otherwise, leave it to SizeChanged to update.
                        if (this.ActualHeight > 0)
                        {
                            AdminCell.Height = this.ActualHeight * 0.3;
                        }

                        AdminCell.Background = new SolidColorBrush(Colors.LightBlue);

                        TimeTextBlock.Text = documented.ActualDose ?? "";
                    }
                    else if (entry is AdminTaskViewModel adminTask)
                    {
                        // For pending tasks: center-aligned, height 80% of the cell.
                        AdminCell.VerticalAlignment = VerticalAlignment.Center;
                        if (this.ActualHeight > 0)
                        {
                            AdminCell.Height = this.ActualHeight * 0.8;
                        }

                        // Determine background color:
                        // 1. Red if the scheduled time is old (< DateTime.Now.AddHours(-1)).
                        if (adminTask.ScheduledTime.HasValue && adminTask.ScheduledTime.Value < DateTime.Now.AddHours(-1))
                        {
                            AdminCell.Background = new SolidColorBrush(Colors.Red);
                            TimeTextBlock.Text = (adminTask.Dose ?? "") + "\nLast Admin:";
                        }
                        else
                        {
                            // 2. If this task is the most recent upcoming dose after now, show LightGreen.
                            var pendingEntry = medRecord.PendingAdminEntry;
                            if (pendingEntry != null && object.ReferenceEquals(pendingEntry, adminTask))
                            {
                                AdminCell.Background = new SolidColorBrush(Colors.LightGreen);
                                TimeTextBlock.Text = (adminTask.Dose ?? "") + "\nLast Admin:";
                            }
                            else
                            {
                                // 3. Otherwise, show LightGray.
                                AdminCell.Background = new SolidColorBrush(Colors.LightGray);
                                TimeTextBlock.Text = adminTask.Dose ?? "";
                            }
                        }
                    }
                }
                else
                {
                    TimeTextBlock.Text = string.Empty;
                    AdminCell.Background = new SolidColorBrush(Colors.Transparent);
                }
            }
            else
            {
                TimeTextBlock.Text = string.Empty;
                AdminCell.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private async void AdminCell_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DoubleTapped event fired.");

            // Ensure DataContext is a MedRecordViewModel and a TimeSlot is set.
            if (DataContext is MedRecordViewModel medRecord && !string.IsNullOrEmpty(TimeSlot))
            {
                var entry = medRecord[TimeSlot];
                var pendingEntry = medRecord.PendingAdminEntry;
                // Only allow editing for pending tasks.
                if (entry != null &&
                    entry is AdminTaskViewModel pendingTask &&
                    (pendingTask.ScheduledTime < DateTime.Now ||
                        (pendingEntry != null && object.ReferenceEquals(pendingEntry, entry))))
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
