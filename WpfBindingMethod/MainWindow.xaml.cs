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
using System.ComponentModel;
using WpfBindingMethod.Views;
using WpfBindingMethod.ViewModels;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace WpfBindingMethod
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        public object ViewModel;

        private ButtonTextboxTextBlockView ButtonTextboxTextBlockView = new ButtonTextboxTextBlockView();
        private ButtonTextboxTextBlockViewModel ButtonTextboxTextBlock = new ButtonTextboxTextBlockViewModel();
        private CheckBoxListBoxView CheckBoxListBoxView = new CheckBoxListBoxView();
        private PictureView PictureView = new PictureView();
        private ComboBoxView ComboBoxView = new ComboBoxView();
        private RadioButtonView RadioButtonView = new RadioButtonView();
        private DelegateCloseButtonViewModel DelegateCloseButtonViewModel = new DelegateCloseButtonViewModel();
        private DelegateCloseButtonView DelegateCloseButtonView = new DelegateCloseButtonView();
        private DataGridView DataGridView = new DataGridView();
        private ViewModelFirst ViewModelFirstViewModel = new ViewModelFirst();
        private MoveObjectViewModel MoveObject = new MoveObjectViewModel();
        private ConverterTestViewModel ConverterTest = new ConverterTestViewModel();
        private ColorPickerViewModel ColorPickerTest = new ColorPickerViewModel();
        private MyFavoriteViewModel MyFavorite = new MyFavoriteViewModel();
        private SimulSendKeys SendKey = new SimulSendKeys();
        private ListMouseEvent ListMouseEvent = new ListMouseEvent();
        private DsMySqlTest DsMySqlTest = new DsMySqlTest();
        private const int WsExNoactivate = 0x08000000;
        private const int GwlExstyle = -20;
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var interopHelper = new WindowInteropHelper(this);
            var exStyle = GetWindowLong(interopHelper.Handle, GwlExstyle);
            SetWindowLong(interopHelper.Handle, GwlExstyle, exStyle | WsExNoactivate);
        }

        public MainWindow()
        {
            InitializeComponent();
            
            SelectUserControl.Items.Add("ButtonTextboxTextBlock");
            SelectUserControl.Items.Add("CheckBoxListBox");
            SelectUserControl.Items.Add("Picture");
            SelectUserControl.Items.Add("RadioButton");
            SelectUserControl.Items.Add("ComBoBoxListBox");         
            SelectUserControl.Items.Add("DelegateCloseButton Method1");
            SelectUserControl.Items.Add("DelegateCloseButton Method2");
            SelectUserControl.Items.Add("DataGridView");
            SelectUserControl.Items.Add("ViewModelFirst");
            SelectUserControl.Items.Add("MoveObject");
            SelectUserControl.Items.Add("ConverterTest");
            SelectUserControl.Items.Add("ColorPickerTest");
            SelectUserControl.Items.Add("MyFavorite");
            SelectUserControl.Items.Add("SendKey");
            SelectUserControl.Items.Add("ListMouseEvent");
            SelectUserControl.Items.Add("DsMySqlTest");
            SelectUserControl.SelectedIndex = 15;
        }

        private void NewUserControl(object sender, SelectionChangedEventArgs e)
        {
            switch (SelectUserControl.SelectedIndex)
            {
                case 0:
                    CC1.Content = ButtonTextboxTextBlock.View;
                    break;
                case 1:
                    CC1.Content = CheckBoxListBoxView;

                    break;
                case 2:
                    CC1.Content = PictureView;

                    break;
                case 3:
                    CC1.Content = RadioButtonView;

                    break;
                case 4:
                    CC1.Content = ComboBoxView;
                    break;

                // 2 Method : 
                case 5:
                    // 1.In View Create a Delegate and the button execute this delegate.
                    //   Main window new a View to Content and set View.CloseEvent = close()

                    DelegateCloseButtonView.CloseWindowEvent = () =>
                    {
                        this.Close();
                    };
                    CC1.Content = DelegateCloseButtonView;
                    
                    break;
                case 6:
                    // 2.In ViewModel Create a Delegate and the event execute this delegate.
                    //   Add a View Attribute and set datacontext = this ViewModel
                    //   Main window new a ViewModel.View to Content and set view.CloseEvent = close()
                    //
                    DelegateCloseButtonViewModel.CloseWindowEvent = () =>
                    {
                        this.Close();
                    };
                    CC1.Content = DelegateCloseButtonViewModel.View;

                    break;
                case 7:
                    CC1.Content = DataGridView;
                    break;
                case 8:
                    CC1.Content = ViewModelFirstViewModel.View;
                    break;
                case 9:
                    CC1.Content = MoveObject.View;
                    break;
                case 10:
                    CC1.Content = ConverterTest.View;
                    break;
                case 11:
                    CC1.Content = ColorPickerTest.View;
                    break;
                case 12:
                    CC1.Content = MyFavorite.View;
                    break;
                case 13:
                    CC1.Content = SendKey;
                    break;
                case 14:
                    CC1.Content = ListMouseEvent;
                    break;
                case 15:
                    CC1.Content = DsMySqlTest;
                    break;
                default:
                    break;
            }
        }
    }
}
