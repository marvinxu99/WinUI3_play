using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Common;
using System.Collections.ObjectModel;

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

    public MainMenuViewModel()
    {
        Categories = new ObservableCollection<MenuItemBase>
        {
            new MenuItem { Name = "Summary", Glyph = Symbol.Home, Tooltip = "This is category 1", Tag = "MVVM_play.Views.MountainPage" },
            new MenuItem { Name = "Orders", Glyph = Symbol.Keyboard, Tooltip = "This is category 2", Tag = "MVVM_play.Views.MountainPage" },
            new Separator(),
            new MenuItem { Name = "MAR", Glyph = Symbol.Library, Tooltip = "This is category 3", Tag = "MVVM_play.Views.MarPage" },
            new MenuItem { Name = "MAR Summary", Glyph = Symbol.Mail, Tooltip = "This is category 4", Tag = "MVVM_play.Views.MarSummaryPage" },
            new MenuItem { Name = "Layout Test", Glyph = Symbol.Mail, Tooltip = "Test layout", Tag = "MVVM_play.Views.LayoutTestPage" },
            new MenuItem { Name = "WebView2 Test", Glyph = Symbol.Mail, Tooltip = "Test WebView2", Tag = "MVVM_play.Views.WebView2TestPage" }

        };

        FooterMenuItems = new ObservableCollection<MenuItemBase>
        {
            new MenuItem { Name = "Account", Glyph = Symbol.Contact, Tooltip = "Account Page", Tag = "MVVM_play.Views.AccountPage" },
            new MenuItem { Name = "About", Glyph = Symbol.Help, Tooltip = "About Page", Tag = "MVVM_play.Views.AboutPage" }
        };
    }
}
