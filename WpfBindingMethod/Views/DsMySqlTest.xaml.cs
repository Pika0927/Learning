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
using System.Windows.Threading;

namespace WpfBindingMethod.Views
{
    /// <summary>
    /// DsMySqlTest.xaml 的互動邏輯
    /// </summary>
    /// 

    public partial class DsMySqlTest : UserControl
    {
        public ds_API_SqlClass.ds_config_api check_lan = new ds_API_SqlClass.ds_config_api();
        public ds_API_SqlClass.ds_language_api class_language = new ds_API_SqlClass.ds_language_api("ds_CCD_proj");
        public DispatcherTimer Timer1 = new DispatcherTimer();
        string language_temp;
        string language_path;

        public DsMySqlTest()
        {
            InitializeComponent();
            Timer1.Interval = TimeSpan.FromSeconds(1);
            Timer1.Tick += RenewLanguage;
            Timer1.Start();

        }

        private void RenewLanguage(object sender, EventArgs e)
        {
            //language_temp = "15";
            string lan = check_lan.getlanguage_set();
            string language_now = check_lan.getlanguage_set();
            if (language_now == "15")
                language_path = "CH_";
            else
                language_path = "ENG_";

            if (language_now != language_temp)
            {
                La0.Content = class_language.TextString("strCCDtitle");
                La1.Content = class_language.TextString("strNCState");
                La2.Content = class_language.TextString("strSpindleToolNum");
                La3.Content = class_language.TextString("strPreStageTool");
                La4.Content = class_language.TextString("strRun");
            }
        }
    }
}
