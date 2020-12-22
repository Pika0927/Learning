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
    /// DelegateCloseButtonView.xaml 的互動邏輯
    /// </summary>
    public partial class DelegateCloseButtonView : UserControl
    {
        public DelegateCloseButtonView()
        {
            InitializeComponent();
            CloseWindowEvent = BaseEvent;
        }
        public delegate void CloseWindowDelegate();
        public CloseWindowDelegate CloseWindowEvent;
        
        private void BaseEvent()
        {
            return;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            CloseWindowEvent();
        }
    }
}
