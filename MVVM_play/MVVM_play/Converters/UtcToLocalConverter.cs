using Microsoft.UI.Xaml.Data;
using System;

namespace MVVM_play.Converters;

internal partial class UtcToLocalConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is DateTime utcTime)
        {
            return utcTime.ToLocalTime().ToString("dd-MMM-yyyy HH:mm");
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is string dateString && DateTime.TryParse(dateString, out DateTime localDateTime))
        {
            return localDateTime.ToUniversalTime();
        }
        return value;
    }
}
