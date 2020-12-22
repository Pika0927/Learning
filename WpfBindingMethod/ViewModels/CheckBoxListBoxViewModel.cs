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

namespace WpfBindingMethod.ViewModels
{
    public class MyList
    {

        public string Name { get; set; }
        public int Index { get; set; }
        
        public MyList(int index, string name)
        {
            Name = name;
            Index = index;
        }

    }
    public class MyCheckBox
    {

        public string Name { get; set; }
        public bool IsChecked { get; set; }
        public ICommand CheckChange { get; set; }
        public MyCheckBox(bool check, string name, ICommand event1)
        {
            Name = name;
            IsChecked = check;
            CheckChange = event1;
        }

    }
    public class CheckBoxListBoxViewModel : ViewModelBase
    {
        public ObservableCollection<string> _ListBoxSource1 = new ObservableCollection<string>();
        public ObservableCollection<string> ListBoxSource1
        {
            get
            {
                if (_ListBoxSource1.Count < 1)
                {
                    _ListBoxSource1.Add("false");
                    _ListBoxSource1.Add("false");
                    _ListBoxSource1.Add("false");
                    _ListBoxSource1.Add("false");
                    _ListBoxSource1.Add("false");
                }
                return _ListBoxSource1;
            }
           
        }
        public ObservableCollection<MyList> _ListBoxSource2 = new ObservableCollection<MyList>();
        public ObservableCollection<MyList> ListBoxSource2
        {
            get
            {
                if (_ListBoxSource2.Count < 1)
                {
                    _ListBoxSource2.Add(new MyList(0, "false"));
                    _ListBoxSource2.Add(new MyList(1, "false"));
                    _ListBoxSource2.Add(new MyList(2, "false"));
                    _ListBoxSource2.Add(new MyList(3, "false"));
                    _ListBoxSource2.Add(new MyList(4, "false"));
                }
                return _ListBoxSource2;
            }
        }
        public ObservableCollection<MyCheckBox> _ListBoxSource3 = new ObservableCollection<MyCheckBox>();
        public ObservableCollection<MyCheckBox> ListBoxSource3
        {
            get
            {
                if (_ListBoxSource3.Count < 1)
                {
                    _ListBoxSource3.Add(new MyCheckBox(true,"CB1", CheckChange));
                    _ListBoxSource3.Add(new MyCheckBox(false, "CB2", CheckChange));
                    _ListBoxSource3.Add(new MyCheckBox(true, "CB3", CheckChange));
                    _ListBoxSource3.Add(new MyCheckBox(true, "CB4", CheckChange));
                    _ListBoxSource3.Add(new MyCheckBox(true, "CB5", CheckChange));
                }
                return _ListBoxSource3;
            }
        }
        private int _SelectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _SelectedIndex;
            }
            set
            {
                _SelectedIndex = value;
                OnPropertyChanged();
            }
        }

        #region CheckBox IsCheck
        private bool _CB1Check;
        public bool CB1Check
        {
            get
            {
                return _CB1Check;
            }
            set
            {
                _CB1Check = value;
                ListBoxSource1[0] = value.ToString();
                MyList tmp = ListBoxSource2[0];
                tmp.Name = value.ToString();
                ListBoxSource2.RemoveAt(0);
                ListBoxSource2.Insert(0, tmp);
                OnPropertyChanged();



            }
        }
        private bool _CB2Check;
        public bool CB2Check
        {
            get
            {
                return _CB2Check;
            }
            set
            {
                _CB2Check = value;
                ListBoxSource1[1] = value.ToString();
                MyList tmp = ListBoxSource2[1];
                tmp.Name = value.ToString();
                ListBoxSource2.RemoveAt(1);
                ListBoxSource2.Insert(1, tmp);
                OnPropertyChanged();
            }
        }
        private bool _CB3Check;
        public bool CB3Check
        {
            get
            {
                return _CB3Check;
            }
            set
            {
                _CB3Check = value;
                ListBoxSource1[2] = value.ToString();
                MyList tmp = ListBoxSource2[2];
                tmp.Name = value.ToString();
                ListBoxSource2.RemoveAt(2);
                ListBoxSource2.Insert(2, tmp);
                OnPropertyChanged();
            }
        }
        private bool _CB4Check;
        public bool CB4Check
        {
            get
            {
                return _CB4Check;
            }
            set
            {
                _CB4Check = value;
                ListBoxSource1[3] = value.ToString();
                MyList tmp = ListBoxSource2[3];
                tmp.Name = value.ToString();
                ListBoxSource2.RemoveAt(3);
                ListBoxSource2.Insert(3, tmp);
                OnPropertyChanged();
            }
        }
        private bool _CB5Check;
        public bool CB5Check
        {
            get
            {
                return _CB5Check;
            }
            set
            {
                _CB5Check = value;
                ListBoxSource1[4] = value.ToString();
                MyList tmp = ListBoxSource2[4];
                tmp.Name = value.ToString();
                ListBoxSource2.RemoveAt(4);
                ListBoxSource2.Insert(4, tmp);
                OnPropertyChanged();
            }
        }
        private string _TestMessage;
        public string TestMessage
        {
            get
            {
                return _TestMessage;
            }
            set
            {
                _TestMessage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand Button1Click { get; set; }
        private bool CanButton1Click(object param)
        {
            return true;
        }
        public void _Button1Click(object param)
        {
            ListBoxSource2[0].Index++;
            ListBoxSource2[0].Name += "a";
            ListBoxSource2.RemoveAt(2);
            ListBoxSource2.Add(new MyList(ListBoxSource2[0].Index, ListBoxSource2[0].Name));
            ListBoxSource2[0] = ListBoxSource2[0];
            
            TestMessage = ListBoxSource3[0].IsChecked.ToString();

        }
        public ICommand CheckChange { get; set; }
        private bool CanCheckChange(object param)
        {
            return true;
        }
        public void _CheckChange(object param)
        {
            TestMessage = "state : ";
            foreach (MyCheckBox item in ListBoxSource3)
            {
               if (item.IsChecked)
                {
                    TestMessage += "1";
                }
                else
                {
                    TestMessage += "0";
                }
            }
        }

        public CheckBoxListBoxViewModel()
        {           
            SelectedIndex = 0;
            Button1Click = new DelegateCommand(_Button1Click, CanButton1Click);
            CheckChange = new DelegateCommand(_CheckChange, CanCheckChange);
            TestMessage = ListBoxSource3[0].IsChecked.ToString();
        }
        
    }
}
