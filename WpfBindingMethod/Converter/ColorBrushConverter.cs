using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfBindingMethod.Converter
{
    class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string ColorString = value.ToString();
                return new SolidColorBrush(Color.FromArgb(
                byte.Parse(ColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(ColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(ColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(ColorString.Substring(7, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            catch (Exception)
            {
                return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return null;
        }
    }

}
