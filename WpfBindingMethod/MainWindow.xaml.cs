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
        private CheckBoxListBoxView CheckBoxListBoxView = new CheckBoxListBoxView();
        private PictureView PictureView = new PictureView();
        private ComboBoxView ComboBoxView = new ComboBoxView();
        private RadioButtonView RadioButtonView = new RadioButtonView();
        private DelegateCloseButtonViewModel DelegateCloseButtonViewModel = new DelegateCloseButtonViewModel();
        private DelegateCloseButtonView DelegateCloseButtonView = new DelegateCloseButtonView();
        private DataGridView DataGridView = new DataGridView();
        private ViewModelFirst ViewModelFirstViewModel = new ViewModelFirst();
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

            

            SelectUserControl.SelectedIndex = 7;
        }

        private void NewUserControl(object sender, SelectionChangedEventArgs e)
        {
            switch (SelectUserControl.SelectedIndex)
            {
                case 0:
                    CC1.Content =ButtonTextboxTextBlockView;
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
                default:
                    break;
            }
        }
    }
}
