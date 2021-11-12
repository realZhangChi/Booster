using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace Booster.WeChat.Converters;

public class WebNavigatingEventArgsConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is not WebNavigatingEventArgs eventArgs
            ? throw new ArgumentException("Expected WebNavigatingEventArgs as value", "value")
            : eventArgs.Url;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
