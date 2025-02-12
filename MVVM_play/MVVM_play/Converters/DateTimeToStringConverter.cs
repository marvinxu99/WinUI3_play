using Microsoft.UI.Xaml.Data;
using System;

namespace MVVM_play.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString("yyyy-MM-dd HH:mm"); // Customize as needed
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (DateTime.TryParse(value as string, out DateTime result))
            {
                return result;
            }
            return DateTime.Now;
        }
    }
}
