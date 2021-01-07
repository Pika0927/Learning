using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBindingMethod.Views
{
    /// <summary>
    /// DataGridView.xaml 的互動邏輯
    /// </summary>
    public partial class DataGridView : UserControl
    {
        List<string> source = new List<string>() {"1","2","3", "4", "5", "6", "7", "8", "9", "10" };
        public DataGridView()
        {
            InitializeComponent();
            IC1.ItemsSource = source;
            SV1.ScrollToEnd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SV1.ScrollToVerticalOffset(0);

        }
    }
}
