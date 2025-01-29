using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Common;
using System.Collections.ObjectModel;

namespace MVVM_play.ViewModels;

public partial class MainViewModel : ObservableObject
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

    public MainViewModel()
    {
        Categories = new ObservableCollection<MenuItemBase>
        {
            new MenuItem { Name = "Summary", Glyph = Symbol.Home, Tooltip = "This is category 1", Tag = "MVVM_play.Views.MountainPage" },
            new MenuItem { Name = "Orders", Glyph = Symbol.Keyboard, Tooltip = "This is category 2", Tag = "MVVM_play.Views.MountainPage" },
            new Separator(),
            new MenuItem { Name = "MAR", Glyph = Symbol.Library, Tooltip = "This is category 3", Tag = "MVVM_play.Views.AboutPage" },
            new MenuItem { Name = "MAR Summary", Glyph = Symbol.Mail, Tooltip = "This is category 4", Tag = "MVVM_play.Views.AboutPage" }
        };

        FooterMenuItems = new ObservableCollection<MenuItemBase>
        {
            new MenuItem { Name = "Account", Glyph = Symbol.Contact, Tooltip = "Account Page", Tag = "MVVM_play.Views.AccountPage" },
            new MenuItem { Name = "About", Glyph = Symbol.Help, Tooltip = "About Page", Tag = "MVVM_play.Views.AboutPage" }
        };
    }
}
