using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Diagnostics;
namespace WpfBindingMethod.Converter
{
    class CirPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return new Point(System.Convert.ToDouble(parameter), System.Convert.ToDouble(value));
            }
            catch (Exception e)
            {
                Debug.WriteLine("**********"+parameter.ToString()+" "+value.ToString() +"**********"+ e+"**********");
                return new Point(0,0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
    class CirPointConverter2 : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return new Point(System.Convert.ToDouble(value[0]), System.Convert.ToDouble(value[1]));
            }
            catch (Exception e)
            {
                Debug.WriteLine("**********" + value[0].ToString() + " " + value[1].ToString() + "**********" + e + "**********");

                return new Point(0, 0);
            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return null;
        }
    }

}
