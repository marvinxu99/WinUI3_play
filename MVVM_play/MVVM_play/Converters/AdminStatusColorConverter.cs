using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;

namespace MVVM_play.Converters
{
    public class AdminStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool wasAdministered)
            {
                return new SolidColorBrush(wasAdministered ? Microsoft.UI.Colors.Blue : Microsoft.UI.Colors.Red);
            }
            return new SolidColorBrush(Microsoft.UI.Colors.Gray);
        }

        public object? ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null; // No need for two-way binding
        }
    }
}
