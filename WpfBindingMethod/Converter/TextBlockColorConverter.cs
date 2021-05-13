using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfBindingMethod.Converter
{
    class TextBlockColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                double Value = System.Convert.ToDouble(value);
                if (parameter!= null && parameter.ToString()== value.ToString())
                {
                    return new SolidColorBrush(Colors.Tan);
                }
                if (Value < 0)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else if(Value<100)
                {
                    return new SolidColorBrush(Colors.Green);
                }
                else if (Value < 1000)
                {
                    return new SolidColorBrush(Colors.Blue);
                }
                else
                {
                    return new SolidColorBrush(Colors.HotPink);
                }
            }
            catch (Exception)
            {
                return new SolidColorBrush(Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           
            return null;
        }
    }

    class TextBlockColorConverterM : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                double Value = System.Convert.ToDouble(value[0]);
                double Max = System.Convert.ToDouble(value[1]);
                double Min = System.Convert.ToDouble(value[2]);

                if(Value>Min && Value < Max)
                {
                    return new SolidColorBrush(Colors.Green);
                }
                else
                {
                    return new SolidColorBrush(Colors.Red);
                }

            }
            catch (Exception)
            {
                return new SolidColorBrush(Colors.Black);
            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return null;
        }
    }
}
