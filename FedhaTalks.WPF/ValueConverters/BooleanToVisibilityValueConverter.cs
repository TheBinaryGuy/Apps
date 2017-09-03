using System;
using System.Globalization;
using System.Windows;

namespace FedhaTalks.WPF
{
    /// <summary>
    /// A converter that takes in a bool and returns <see cref="Visibility"/>
    /// </summary>
    public class BooleanToVisibilityValueConverter : BaseValueConverter<BooleanToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Hidden : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
