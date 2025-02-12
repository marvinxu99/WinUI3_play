using Microsoft.UI.Xaml.Data;
using System;

namespace MVVM_play.Converters
{
    public class BoolToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is bool b && b ? "Yes" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is string s && s.Equals("Yes", StringComparison.OrdinalIgnoreCase);
        }
    }
}
