using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace LinkedSpace.View.ValueConverters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => GetParameter(parameter) == (bool)value ? Visibility.Visible : Visibility.Collapsed;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new InvalidOperationException(Converters.ONE_WAY_CONVERTER_EXCEPTION);
        private bool GetParameter(object parameter) => bool.TryParse(parameter.ToString(), out bool b) ? b : true;
    }
}