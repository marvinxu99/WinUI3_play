using Microsoft.UI.Xaml.Controls;
using MVVM_play.ViewModels;

namespace MVVM_play.Views
{
    public sealed partial class MarPage : Page
    {
        public MarPage()
        {
            this.InitializeComponent();
            DataContext = new MarViewModel();
        }
    }
}
