using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfBindingMethod.Converter
{
    class TransformConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                TranslateTransform Trans = value as TranslateTransform;
                if (Trans != null)
                {
                    Trans.X *= -2;
                    Trans.Y *=-2;
                }
                return Trans;
            }
            catch (Exception)
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
