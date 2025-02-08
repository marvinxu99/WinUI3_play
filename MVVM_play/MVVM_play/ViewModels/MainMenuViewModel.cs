using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Common;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MVVM_play.ViewModels;

public partial class MainMenuViewModel : ObservableObject
{
    private ObservableCollection<MenuItemBase> _categories = null!;
    public ObservableCollection<MenuItemBase> Categories
    {
        get => _categories;
        set => SetProperty(ref _categories, value);
    }

    private ObservableCollection<MenuItemBase> _footerMenuItems = null!;
    public ObservableCollection<MenuItemBase> FooterMenuItems
    {
        get => _footerMenuItems;
        set => SetProperty(ref _footerMenuItems, value);
    }

    public RelayCommand NewCommand { get; }
    public RelayCommand OpenCommand { get; }
    public RelayCommand ExitCommand { get; }
    public RelayCommand UndoCommand { get; }
    public RelayCommand RedoCommand { get; }
    public RelayCommand AboutCommand { get; }


    public MainMenuViewModel()
    {
        Categories = [
            new MenuItem { Name = "Summary", Glyph = Symbol.Home, Tooltip = "This is category 1", Tag = "MVVM_play.Views.MountainPage" },
            new MenuItem { Name = "Orders", Glyph = Symbol.Keyboard, Tooltip = "This is category 2", Tag = "MVVM_play.Views.MountainPage" },

            new Separator(),

            new MenuItem { Name = "MAR", Glyph = Symbol.Library, Tooltip = "This is category 3", Tag = "MVVM_play.Views.MarPage" },
            new MenuItem { Name = "MAR Summary", Glyph = Symbol.Mail, Tooltip = "This is category 4", Tag = "MVVM_play.Views.MarSummaryPage" },

            new Separator(),

            //new MenuItem { Name = "Layout Test", Glyph = Symbol.Mail, Tooltip = "Test layout", Tag = "MVVM_play.Views.LayoutTestPage" },
            //new MenuItem { Name = "WebView2 Test", Glyph = Symbol.Mail, Tooltip = "Test WebView2", Tag = "MVVM_play.Views.WebView2TestPage" },
            new MenuItem { Name = "Person Select", Glyph = Symbol.Mail, Tooltip = "Select a person", Tag = "MVVM_play.Views.PersonSelectPage" },

            new Separator(),

            new MenuItem { Name = "Dynamic DataGrid", Glyph = Symbol.Mail, Tooltip = "Dynamic DataGrid", Tag = "MVVM_play.Views.DynamicDataGridPage" },
            new MenuItem { Name = "Dynamic DataGrid2", Glyph = Symbol.Mail, Tooltip = "Dynamic DataGrid2", Tag = "MVVM_play.Views.DynamicDataGrid2Page" },
            new MenuItem { Name = "DataGrid DB CRUD", Glyph = Symbol.Mail, Tooltip = "Datagrid with CRUD", Tag = "MVVM_play.Views.DataGridWithCrudPage" },

            new Separator(),

            new MenuItem { Name = "DataGrid MergedData", Glyph = Symbol.Mail, Tooltip = "Datagrid with Merged Data", Tag = "MVVM_play.Views.DataGridMergedDataPage" },

        ];

        FooterMenuItems = [
            new MenuItem { Name = "Account", Glyph = Symbol.Contact, Tooltip = "Account Page", Tag = "MVVM_play.Views.AccountPage" },
            new MenuItem { Name = "About", Glyph = Symbol.Help, Tooltip = "About Page", Tag = "MVVM_play.Views.AboutPage" },
        ];

        NewCommand = new RelayCommand(() => Debug.WriteLine("New clicked"));
        OpenCommand = new RelayCommand(() => Debug.WriteLine("Open clicked"));
        ExitCommand = new RelayCommand(() => Debug.WriteLine("Exit clicked"));
        UndoCommand = new RelayCommand(() => Debug.WriteLine("Undo clicked"));
        RedoCommand = new RelayCommand(() => Debug.WriteLine("Redo clicked"));
        AboutCommand = new RelayCommand(() => Debug.WriteLine("About clicked"));
    }
}
