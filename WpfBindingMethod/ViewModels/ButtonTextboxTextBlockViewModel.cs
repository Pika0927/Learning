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
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WpfBindingMethod.Views;

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
        private int _IntText;

        public int IntText
        {
            get { return _IntText; }
            set
            {
                _IntText = value;
                OnPropertyChanged();
            }
        }
        private string _StringText;

        public string StringText
        {
            get { return _StringText; }
            set
            {
                _StringText = value;
                OnPropertyChanged();
            }
        }

        private int _TextString2;

        public int TextString2
        {
            get { return _TextString2; }
            set
            {
                _TextString2 = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ButtonList> _MyButtonList = new ObservableCollection<ButtonList>();
        public ObservableCollection<ButtonList> MyButtonList
        {
            get
            {
                if (_MyButtonList.Count < 1)
                {
                    _MyButtonList.Add(new ButtonList("Add1"));
                    _MyButtonList.Add(new ButtonList("Add2"));
                    _MyButtonList.Add(new ButtonList("Add3"));

                }
                return _MyButtonList;
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

        public ButtonTextboxTextBlockView View = new ButtonTextboxTextBlockView();
        public ButtonTextboxTextBlockViewModel()
        {
            View.DataContext = this;
            Button1Content = "Add 1 ";
            TextBox1 = "1";
            Button1Click = new DelegateCommand(_Button1Click, CanButton1Click);
            IntText = 123;
            StringText = "string";
            TextString2 = 0;
        }
        public void AddButton2(object sender, EventArgs e)
        {
            Button Tmp = sender as Button;
            Tmp.Content += "B";
            TextString2++;
        }


    }

    public class ButtonList : ViewModelBase
    {
        private string _ButtonName;

        public string ButtonName
        {
            get { return _ButtonName; }
            set
            {
                _ButtonName = value;
                OnPropertyChanged();
            }
        }
        public ButtonList()
        {
            AddButton3 = new DelegateCommand(_AddButton3, CanButton1Click);

        }
        public ButtonList(string Name)
        {
            ButtonName = Name;
            AddButton3 = new DelegateCommand(_AddButton3, CanButton1Click);

        }
        private bool CanButton1Click(object param)
        {
            return false;
        }
        public ICommand AddButton3 { get; set; }

        public void _AddButton3(object param)
        {
            string Tmp = param.ToString();
            ButtonName = Tmp + "A";
        }
    }


}
