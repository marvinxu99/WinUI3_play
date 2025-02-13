using Microsoft.UI.Xaml;
using MVVM_play.ViewModels;

namespace MVVM_play;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainMenuViewModel ViewModel { get; }

    public MainWindow()
    {
        this.InitializeComponent();

        // Initialize ViewModel
        ViewModel = new MainMenuViewModel();
        // Set DataContext on the root element (e.g., the Grid in XAML)
        RootGrid.DataContext = ViewModel;

        // Get the AppWindow for controlling window size
        //IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
        //WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
        //if (AppWindow.GetFromWindowId(myWndId).Presenter is OverlappedPresenter presenter)
        //{
        //    presenter.Maximize();
        //}

    }
}
