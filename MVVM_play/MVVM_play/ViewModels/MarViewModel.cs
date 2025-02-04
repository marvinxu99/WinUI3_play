using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MVVM_play.ViewModels;

internal class MarTask
{
    public string Name { get; set; }
    public string TaskTime { get; set; }

    public MarTask(string name, string taskTime)
    {
        Name = name;
        TaskTime = taskTime;
    }
}

internal class MarResult
{
    public string Name { get; set; }
    public string ResultTime { get; set; }

    public MarResult(string name, string resultTime)
    {
        Name = name;
        ResultTime = resultTime;
    }
}

internal class MarRowItem
{
    public string OrderName { get; set; }
    public int OrderType { get; }
    public List<MarTask>? Tasks { get; set; }
    public List<MarResult>? Results { get; set; }

    public MarRowItem(string orderName, int orderType)
    {
        OrderType = orderType;
        OrderName = orderName;
    }
}

internal partial class MarViewModel : ObservableObject
{
    private MarRowItem? _selectedMarRow;

    public ObservableCollection<MarRowItem>? MarRows { get; set; }

    public MarRowItem? SelectedMarRow
    {
        get => _selectedMarRow;
        set => SetProperty(ref _selectedMarRow, value);
    }


    public RelayCommand RefreshMarCommand { get; }


    public MarViewModel()
    {
        // Sample data
        MarRows = new ObservableCollection<MarRowItem>
        {
            new("Order1", 1),
            new("Order2", 1),
            new("Order3", 2),
            new("Order4", 2),
            new("Order5", 3),
            new("Order6", 3),
            new("Order7", 3),
        };

        RefreshMarCommand = new RelayCommand(RefreshMar);

    }

    private void RefreshMar()
    {
        Debug.WriteLine($"RefreshMar()");
    }

    public void MarGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("Selected Changed");
    }

    public void MarGrid_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        Debug.WriteLine("key pressed!");
    }


}
