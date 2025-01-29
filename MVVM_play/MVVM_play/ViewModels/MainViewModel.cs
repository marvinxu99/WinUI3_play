using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Common;
using System.Collections.ObjectModel;

namespace MVVM_play.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<CategoryBase> _categories;

    [ObservableProperty]
    private ObservableCollection<CategoryBase> _footerMenuItems;

    public MainViewModel()
    {
        Categories = new ObservableCollection<CategoryBase>
        {
            new Category { Name = "Category 1", Glyph = Symbol.Home, Tooltip = "This is category 1", Tag = "MVVM_play.Views.MountainPage" },
            new Category { Name = "Category 2", Glyph = Symbol.Keyboard, Tooltip = "This is category 2", Tag = "MVVM_play.Views.MountainPage" },
            new Separator(),
            new Category { Name = "Category 3", Glyph = Symbol.Library, Tooltip = "This is category 3", Tag = "MVVM_play.Views.AboutPage" },
            new Category { Name = "Category 4", Glyph = Symbol.Mail, Tooltip = "This is category 4", Tag = "MVVM_play.Views.AboutPage" }
        };

        FooterMenuItems = new ObservableCollection<CategoryBase>
        {
            new Category { Name = "Account", Glyph = Symbol.Contact, Tooltip = "Account Page", Tag = "MVVM_play.Views.AccountPage" },
            new Category { Name = "About", Glyph = Symbol.Help, Tooltip = "About Page", Tag = "MVVM_play.Views.AboutPage" }
        };
    }
}
