using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using MVVM_play.ViewModels;

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
                        new SolidColorBrush(Colors.LightGreen) :
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
    }
}
