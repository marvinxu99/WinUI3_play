using Microsoft.UI.Xaml.Controls;
using MVVM_play.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MarPage : Page
{
    private MarViewModel ViewModel { get; }

    public MarPage()
    {
        this.InitializeComponent();

        ViewModel = new MarViewModel();  // Create ViewModel instance
        DataContext = ViewModel;            // Assign DataContext
    }
}
