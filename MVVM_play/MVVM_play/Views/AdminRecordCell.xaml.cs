using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using MVVM_play.ViewModels;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Views
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
            // Ensure both the DataContext and TimeSlot are set.
            if (DataContext is MedRecordViewModel medRecord && !string.IsNullOrEmpty(TimeSlot))
            {
                // Use the indexer to look up the admin record.
                var adminRecord = medRecord[TimeSlot];
                if (adminRecord != null)
                {
                    // Display the administration time (formatted) or any other info you want.
                    TimeTextBlock.Text = adminRecord.AdministrationTime.ToString("dd-MMM HH:mm");
                    // Change background color based on WasAdministered.
                    CellBorder.Background = adminRecord.WasAdministered ?
                        new SolidColorBrush(Colors.LightBlue) :
                        new SolidColorBrush(Colors.LightGray);
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

            // Ensure the DataContext is a MedRecordViewModel.
            if (DataContext is MedRecordViewModel medRecord && !string.IsNullOrEmpty(TimeSlot))
            {
                var adminRecord = medRecord[TimeSlot];
                // Allow update only if the admin record exists, is not administered, and is the pending record.
                if (adminRecord != null &&
                    !adminRecord.WasAdministered &&
                    (adminRecord.AdministrationTime < DateTime.Now || medRecord.PendingAdminRecord == adminRecord))
                {
                    // Show the dialog to update details.
                    var dialog = new UpdateAdminRecordDialog();

                    // Set the XamlRoot to the current control's XamlRoot.
                    dialog.XamlRoot = this.XamlRoot;

                    // Pre-populate dialog fields (if desired)
                    dialog.AdminTimePicker.Date = adminRecord.AdministrationTime;
                    dialog.ActualDoseTextBox.Text = adminRecord.ActualDose;
                    dialog.NurseNameTextBox.Text = adminRecord.AdministeredBy;

                    var result = await dialog.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        // Update the admin record with entered values.
                        adminRecord.AdministrationTime = dialog.AdminTimePicker.Date.DateTime;
                        adminRecord.ActualDose = dialog.ActualDoseTextBox.Text;
                        adminRecord.AdministeredBy = dialog.NurseNameTextBox.Text;
                        adminRecord.WasAdministered = true;
                        // Optionally, update Notes or other fields here.

                        // Refresh cell appearance.
                        UpdateContent();
                    }
                }
            }
        }
    }
}
