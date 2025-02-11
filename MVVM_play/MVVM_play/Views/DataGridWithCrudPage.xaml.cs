using Microsoft.UI.Xaml.Controls;
using MVVM_play.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataGridWithCrudPage : Page
    {
        private UserViewModel ViewModel { get; }

        /*
         * Added this in order for CententFrame.Navigate() to work
         * (NavigationView_SelectionChange() in MainWindow.xaml.navigation.cs)
         */
        public DataGridWithCrudPage() : this(App.GetService<UserViewModel>()) { }

        public DataGridWithCrudPage(UserViewModel userViewModel)
        {
            this.InitializeComponent();

            //ViewModel = App.GetService<UserViewModel>();
            ViewModel = userViewModel;       // using Contructor DI

            DataContext = ViewModel;            // Assign DataContext
        }
    }
}
