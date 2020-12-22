using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoraMVVM.Helper;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WpfBindingMethod.ViewModels
{
    class ComboBoxViewModel : ViewModelBase
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
        public ObservableCollection<string> _ItemList = new ObservableCollection<string>();
        public ObservableCollection<string> ItemList
        {
            get
            {            
                return _ItemList;
            }
        }

        private int _SelectIndex;

        public int SelectIndex
        {
            get {
               
                return _SelectIndex; }
            set {
                _SelectIndex = value;
                OnPropertyChanged();
            }
        }
        private string _SelectItem;

        public string SelectItem
        {
            get { return _SelectItem; }
            set { _SelectItem = value;
                OnPropertyChanged();
                Text1 = SelectIndex.ToString()+" : " +SelectItem;
            }
        }

        private string _Text1;

        public string Text1
        {
            get { return _Text1; }
            set { _Text1 = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region ICommand
        #region Use Method, Func<> CanEventName can use CanExecute to replace 
        /*
        public ICommand EventName { get; set; }

        private bool CanEventName(object param)
        {
            return true;
        }
        public void _EventName(object param)
        {
          Code
        }
        */
        private bool CanExecute(object param)
        {
            return true;
        }
        #endregion


        #endregion

        public ComboBoxViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                ItemList.Add(i.ToString());
            }
            SelectItem = ItemList[0];

        }
    }
}
