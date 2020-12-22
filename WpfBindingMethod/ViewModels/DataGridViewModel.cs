using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoraMVVM.Helper;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WpfBindingMethod.ViewModels
{
    public class MyDataGird : ViewModelBase
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Zokusei { get; set; } //日本語や中国語に変えても大丈夫です
        public MyDataGird(int index, string name, string zokusei)
        {
            Index = index;
            Name = name;
            Zokusei = zokusei;
        }
    }
    public class DataGridViewModel:ViewModelBase
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
        public ObservableCollection<MyDataGird> _DataGirdSource = new ObservableCollection<MyDataGird>();
        public ObservableCollection<MyDataGird> DataGirdSource
        {
            get
            {
                return _DataGirdSource;
            }
        }
        private string _ChangeText;

        public string ChangeText
        {
            get {               
                return _ChangeText; }
            set { _ChangeText = value;
                OnPropertyChanged();
            }
        }

        private int _SelectIndex;

        public int SelectIndex
        {
            get { return _SelectIndex; }
            set { _SelectIndex = value; }
        }

        private string _SelectedItem;

        public string SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; }
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
        
        public ICommand CellEditEnding { get; set; }

        private void _CellEditEnding(object param)
        {
            ChangeText = DataGirdSource[0].Index.ToString();
            
        }

        public ICommand SelectedCellsChanged { get; set; }

        private void _SelectedCellsChanged(object param)
        {
            ChangeText = string.Format("Index : {0} Name : {1}", SelectIndex,SelectedItem);

        }


        public ICommand ButtonClick { get; set; }

        private void _ButtonClick(object param)
        {
            ChangeText = DataGirdSource[0].Index.ToString();
        }
        #endregion
        public DataGridViewModel()
        {
            DataGirdSource.Add(new MyDataGird(1, "アニラ", "火"));
            DataGirdSource.Add(new MyDataGird(3, "ヴァジラ", "水"));
            DataGirdSource.Add(new MyDataGird(3, "マキラ", "土"));
            DataGirdSource.Add(new MyDataGird(4, "アンチラ", "風"));
            DataGirdSource.Add(new MyDataGird(5, "リリィ", "光"));
            DataGirdSource.Add(new MyDataGird(6, "ピカラ", "闇"));
            
            CellEditEnding = new DelegateCommand(_CellEditEnding,CanExecute);
            ButtonClick = new DelegateCommand(_ButtonClick, CanExecute);
            SelectedCellsChanged = new DelegateCommand(_SelectedCellsChanged, CanExecute);
            
        }

    }
}
