using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVVM_play.Controls;

public sealed partial class UserControl1 : UserControl
{
    public UserControl1()
    {
        this.InitializeComponent();
        this.LabelText = "Default Text";
        MyButton.Click += OnButtonClick;  // ? Attach event handler in C#
    }

    // Custom property to set Label Text
    public string LabelText
    {
        get => (string)GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    public static readonly DependencyProperty LabelTextProperty =
        DependencyProperty.Register(nameof(LabelText), typeof(string), typeof(UserControl1),
            new PropertyMetadata("Default Text", OnLabelTextChanged));

    private static void OnLabelTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is UserControl1 control && e.NewValue is string newText && control.MyLabel != null)
        {
            control.MyLabel.Text = newText;
        }
    }

    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        MyLabel.Text = "Button Clicked!";
    }

    public int GetSeven()
    {
        return 7;
    }

}
