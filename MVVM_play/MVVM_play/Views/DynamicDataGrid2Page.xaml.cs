using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Models;
using System.Collections.Generic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class DynamicDataGrid2Page : Page
{
    private readonly DatabaseContext _dbContext = new();

    public DynamicDataGrid2Page()
    {
        this.InitializeComponent();
        _dbContext.InitializeDatabase(); // Ensure database is initialized
        LoadDataFromDatabase();
    }

    private async void LoadDataFromDatabase()
    {
        string tableName = "Users";  // Set your table name

        // Fetch column names
        List<string> columnNames = await _dbContext.GetColumnNamesAsync(tableName);

        // Clear old columns
        MyDataGrid2.Columns.Clear();

        foreach (var columnName in columnNames)
        {
            MyDataGrid2.Columns.Add(new DataGridTextColumn
            {
                Header = columnName,
                Binding = new Microsoft.UI.Xaml.Data.Binding { Path = new(columnName) }
            });
        }

        // Fetch data
        List<Dictionary<string, object>> data = await _dbContext.GetDataAsync(tableName);

        // Bind data to DataGrid
        MyDataGrid2.ItemsSource = data;
    }
}
