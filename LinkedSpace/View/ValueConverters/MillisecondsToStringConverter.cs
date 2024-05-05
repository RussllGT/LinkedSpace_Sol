using System;
using System.Globalization;
using System.Windows.Data;

namespace LinkedSpace.View.ValueConverters
{
    public class MillisecondsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((TimeSpan)value).TotalMilliseconds.ToString("F3");
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new InvalidOperationException(Converters.ONE_WAY_CONVERTER_EXCEPTION);
    }
}