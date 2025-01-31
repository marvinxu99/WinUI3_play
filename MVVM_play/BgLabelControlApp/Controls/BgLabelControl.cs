using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BgLabelControlApp.Controls;

public sealed class BgLabelControl : Control
{
    public BgLabelControl()
    {
        DefaultStyleKey = typeof(BgLabelControl);
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label),
        typeof(string),
        typeof(BgLabelControl),
        new PropertyMetadata(default(string),
        new PropertyChangedCallback(OnLabelChanged)));

    public bool HasLabelValue { get; set; }

    private static void OnLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        BgLabelControl labelControl = (BgLabelControl)d;
        string? s = e.NewValue as string; //null checks omitted

        //if (String.IsNullOrEmpty(s))
        //{
        //    labelControl.HasLabelValue = false;
        //}
        //else
        //{
        //    labelControl.HasLabelValue = true;
        //}
        labelControl.HasLabelValue = !string.IsNullOrEmpty(s);
    }

}
