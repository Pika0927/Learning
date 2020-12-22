using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Input;
using SoraMVVM.Helper;

namespace WpfBindingMethod.ViewModels
{
    /// <summary>
    /// TextBox TextBlock text binding, TextBlock = TextBox*5
    /// Button click event binding, if click TextBox will + 1
    /// </summary>

    public class ButtonTextboxTextBlockViewModel : ViewModelBase
    {
        #region Binding Data

        private string _TextBlock1;
        public string TextBlock1
        {
            set
            {
                _TextBlock1 = value;
                OnPropertyChanged();
            }
            get
            {
                return _TextBlock1;
            }
        }
        private string _TextBox1;
        public string TextBox1
        {
            set
            {
                _TextBox1 = value;
                try
                {
                    int val = Convert.ToInt32(value);
                    TextBlock1 = (5 * val).ToString();
                }
                catch (Exception e)
                {
                    TextBlock1 = e.ToString();
                    
                }
                
                OnPropertyChanged();
            }
            get
            {
                return _TextBox1;
            }
        }
        private string _Button1Content;
        public string Button1Content
        {
            set
            {
                _Button1Content = value;
                OnPropertyChanged();
            }
            get
            {
                return _Button1Content;
            }
        }       
        private int Count
        {        
            set
            {
                TextBox1 = value.ToString();
            }
            get
            {
                return Convert.ToInt32(TextBox1);
            }
        }
        #endregion
       
        #region ICommand
        public ICommand Button1Click { get; set; }
      
        private bool CanButton1Click(object param)
        {
            return true;
        }
        #endregion
        public void _Button1Click(object param)
        {
            Count++;
            
        }
        public ButtonTextboxTextBlockViewModel()
        {
            Button1Content = "Add 1 ";
            TextBox1 = "1";
            Button1Click = new DelegateCommand(_Button1Click, CanButton1Click);
           
        }
        
      


    }

   
}
