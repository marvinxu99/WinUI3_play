using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.ViewModels;

namespace MVVM_play.Views
{
    public sealed partial class MarPage : Page
    {
        public MarPage()
        {
            this.InitializeComponent();

            // Ensure the page is loaded before modifying the DataGrid columns
            this.Loaded += MarPage_Loaded;
        }

        private void MarPage_Loaded(object sender, RoutedEventArgs e)
        {
            AddTimeSlotColumns();
        }

        private void AddTimeSlotColumns()
        {
            if (DataContext is not MarViewModel viewModel) return;

            // Prevent re-adding columns (assuming static columns already exist)
            if (MarDataGrid.Columns.Count > 2) return;

            foreach (var timeSlot in viewModel.TimeSlots)
            {
                var column = new DataGridTemplateColumn
                {
                    Header = timeSlot,
                    Width = new DataGridLength(110),
                    CellTemplate = CreateAdminRecordCellTemplate(timeSlot)
                };

                MarDataGrid.Columns.Add(column);
            }
        }

        private DataTemplate CreateAdminRecordCellTemplate(string timeSlot)
        {
            // Create a DataTemplate that instantiates AdminRecordCell with TimeSlot set.
            string xamlTemplate = $@"
                <DataTemplate 
                    xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
                    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                    xmlns:local='using:MVVM_play.Views'>
                    <local:AdminRecordCell TimeSlot='{timeSlot}'/>
                </DataTemplate>";

            return (DataTemplate)Microsoft.UI.Xaml.Markup.XamlReader.Load(xamlTemplate);
        }

    }
}
