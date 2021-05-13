using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using SWF = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using System.IO;

namespace WpfBindingMethod.Views
{
    /// <summary>
    /// SimulSendKeys.xaml 的互動邏輯
    /// </summary>
    public partial class SimulSendKeys : UserControl
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);
        public SimulSendKeys()
        {
            InitializeComponent();
        }
        int Count = 48;
        private void KeySendContent(object sender, RoutedEventArgs e)
        {
            //Process p = Process.GetProcessesByName("TextBoxs").FirstOrDefault();
            //p = Process.GetProcessesByName("HartrolNextMainForm.WPFApp").FirstOrDefault();

            //if (p != null)
            //{
            //    IntPtr h = p.MainWindowHandle;
            //    SetForegroundWindow(h);
            //    SWF.SendKeys.SendWait(Te.Text);
            //}
            Te.Text = "-123.456789";
            SendStringToOtherWindow("-123.456789");
            Count++;
        }
        private void SendStringToOtherWindow(string SendData)
        {
            foreach (char item in SendData)
            {
                if(item == '-')
                {
                    keybd_event(189, 0, 0, UIntPtr.Zero);
                }
                else if (item == '.')
                {
                    keybd_event(190, 0, 0, UIntPtr.Zero);
                }
                else
                {
                    keybd_event(Convert.ToByte(item), 0, 0, UIntPtr.Zero);
                }
            }
        }
    }
}
