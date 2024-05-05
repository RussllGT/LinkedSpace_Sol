using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace LinkedSpace.View.ValueConverters
{
    public class VisibilityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility[] visibilities = values.Select(x => (Visibility)x).ToArray();

            bool isVisible;
            if (parameter.ToString() == "And") isVisible = visibilities.All(v => v == Visibility.Visible);
            else if (parameter.ToString() == "Or") isVisible = visibilities.Any(v => v == Visibility.Visible);
            else throw new ArgumentException(Converters.INCORRECT_PARAMETER_EXCEPTION);

            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new InvalidOperationException(Converters.ONE_WAY_CONVERTER_EXCEPTION);
    }
}