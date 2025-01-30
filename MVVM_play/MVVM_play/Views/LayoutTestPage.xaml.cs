using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class LayoutTestPage : Page
{
    public LayoutTestPage()
    {
        this.InitializeComponent();
    }

    private async void myButton_Click(object sender, RoutedEventArgs e)
    {
        myButton.Content = "Clicked";

        var description = new System.Text.StringBuilder();
        var process = System.Diagnostics.Process.GetCurrentProcess();
        foreach (System.Diagnostics.ProcessModule module in process.Modules)
        {
            description.AppendLine(module.FileName);
        }

        cdTextBlock.Text = description.ToString();
        await contentDialog.ShowAsync();
    }
}
