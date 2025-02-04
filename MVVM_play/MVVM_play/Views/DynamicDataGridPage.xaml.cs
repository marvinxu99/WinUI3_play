using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Views;

public class DynamicData : Dictionary<string, object>
{
    public object? this[string columnName]
    {
        get => ContainsKey(columnName) ? base[columnName] : null;
        set => base[columnName] = value;
    }
}

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class DynamicDataGridPage : Page
{
    public DynamicDataGridPage()
    {
        this.InitializeComponent();
        LoadDynamicData();
    }

    private void LoadDynamicData()
    {
        // Define columns dynamically
        List<string> columnNames = new() { "ID", "Name", "Age", "City" };

        // Clear existing columns before adding new ones
        MyDataGrid1.Columns.Clear();

        foreach (var columnName in columnNames)
        {
            MyDataGrid1.Columns.Add(new DataGridTextColumn
            {
                Header = columnName,
                Binding = new Microsoft.UI.Xaml.Data.Binding { Path = new(columnName) }
            });
        }

        // Create dynamic data rows
        List<DynamicData> data = new()
        {
            new DynamicData { ["ID"] = 1, ["Name"] = "Alice", ["Age"] = 25, ["City"] = "Vancouver" },
            new DynamicData { ["ID"] = 2, ["Name"] = "Bob", ["Age"] = 30, ["City"] = "Toronto" },
            new DynamicData { ["ID"] = 3, ["Name"] = "Charlie", ["Age"] = 35, ["City"] = "Calgary" },
            new DynamicData { ["ID"] = 4, ["Name"] = "Charlie", ["Age"] = 35, ["City"] = "Calgary" },
        };

        // Bind data to DataGrid
        MyDataGrid1.ItemsSource = data;
    }
}
