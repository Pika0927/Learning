using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// ListMouseEvent.xaml 的互動邏輯
    /// </summary>
    public partial class ListMouseEvent : UserControl
    {
        public ListMouseEvent()
        {
            InitializeComponent();
            Debug.WriteLine(0.723%0.1);
        }

        private void PDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("PDown");

        }
        private void PUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("PUp");
        }
        private void LDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("LDown");
        }
        private void LUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("LUp");
        }
        private void RDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("RDown");
        }
        private void RUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("RUp");
        }
    }
}
