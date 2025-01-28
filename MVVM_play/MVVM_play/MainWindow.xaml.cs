using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MVVM_play.Common;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.


namespace MVVM_play;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public ObservableCollection<CategoryBase> Categories { get; set; }

    public MainWindow()
    {
        this.InitializeComponent();

        Categories = new ObservableCollection<CategoryBase>
        {
            new Category { Name = "Category 1", Glyph = Symbol.Home, Tooltip = "This is category 1",
                Tag = "MVVM_play.Views.MountainPage" },
            new Category { Name = "Category 2", Glyph = Symbol.Keyboard, Tooltip = "This is category 2",
                Tag = "MVVM_play.Views.MountainPage"  },

            new Separator(),

            new Category { Name = "Category 3", Glyph = Symbol.Library, Tooltip = "This is category 3",
                Tag = "MVVM_play.Views.AboutPage" },
            new Category { Name = "Category 4", Glyph = Symbol.Mail, Tooltip = "This is category 4",
                Tag = "MVVM_play.Views.AboutPage" }
        };

        // Set DataContext on the root element (e.g., the Grid in XAML)
        RootGrid.DataContext = this;
    }


}
