using Microsoft.UI.Xaml;
using MVVM_play.ViewModels;

namespace MVVM_play;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainViewModel ViewModel { get; }

    public MainWindow()
    {
        this.InitializeComponent();

        // Initialize ViewModel
        ViewModel = new MainViewModel();

        // Set DataContext on the root element (e.g., the Grid in XAML)
        RootGrid.DataContext = ViewModel;
    }
}
