using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoraMVVM.Helper;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WpfBindingMethod.ViewModels
{
    public class MyRadioButton
    {
        public bool RBCheck { get; set; }
        public MyRadioButton(bool _RBCheck)
        {
            RBCheck = _RBCheck;
        }
    }
    public class RadioButtonViewModel : ViewModelBase
    {
        #region Useful word and key
        //Useful Word :
        //  prop            建立自動實作的屬性宣告。
        //  propfull        建立具有 get 和 set 存取子的屬性宣告。
        //  ctor            類別建構
        //Useful Key :
        //  Ctrl+k, Ctrl+s  快速範圍陳述式
        //  Ctrl+k, Ctrl+c  註解
        //  Ctrl+k, Ctrl+u  解註解
        //
        #endregion

        #region Binding Data
        private bool _RBCheck1;

        public bool RBCheck1
        {
            get { return _RBCheck1; }
            set { _RBCheck1 = value;
                OnPropertyChanged();
            }
        }
        private bool _RBCheck2;

        public bool RBCheck2
        {
            get { return _RBCheck2; }
            set { _RBCheck2 = value;
                OnPropertyChanged();
            }
        }
        private bool _RBCheck3;

        public bool RBCheck3
        {
            get { return _RBCheck3; }
            set { _RBCheck3 = value;
                OnPropertyChanged();
            }
        }
        private bool _RBCheck4;

        public bool RBCheck4
        {
            get { return _RBCheck4; }
            set { _RBCheck4 = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MyRadioButton> _ListBoxSource1 = new ObservableCollection<MyRadioButton>();

        public ObservableCollection<MyRadioButton> ListBoxSource1
        {
            get { return _ListBoxSource1; }
           
        }

        #endregion

        #region ICommand
        #region Use Method, Func<> CanEventName can use CanExecute to replace 
        /*
        public ICommand EventName { get; set; }
         public void _EventName(object param)
        {
          Code
        }
        private bool CanEventName(object param)
        {
            return true;
        }
       
        */
        private bool CanExecute(object param)
        {
            return true;
        }
        #endregion
        public ICommand Move { get; set; }
        public void _Move(object param)
        {
            index++;
            index %= ListBoxSource1.Count;
            int count = ListBoxSource1.Count;
            ListBoxSource1.Clear();
            for (int i = 0; i < count; i++)
            {
                ListBoxSource1.Add(new MyRadioButton(false));
            }
            ListBoxSource1.RemoveAt(index);
            ListBoxSource1.Insert(index, new MyRadioButton(true));

        }

        #endregion
        private List<bool> RBCheckList = new List<bool>();
        private int index = 0;
        public RadioButtonViewModel()
        {
            RBCheck3 = true;
            ListBoxSource1.Add(new MyRadioButton(true));
            for (int i = 0; i < 3; i++)
            {
                ListBoxSource1.Add(new MyRadioButton(false));              
            }
            
            
            Move = new DelegateCommand(_Move,CanExecute);
        }
    }
}
