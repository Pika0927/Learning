using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoraMVVM.Helper;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WpfBindingMethod.Views;


namespace WpfBindingMethod.ViewModels
{
    public class DelegateCloseButtonViewModel:ViewModelBase
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
        public ICommand CloseWindow { get; set; }
        public void _CloseWindow(object param)
        {
            CloseWindowEvent();
        }

        #endregion
        public delegate void CloseWindowDelegate();
        public CloseWindowDelegate CloseWindowEvent;
        public DelegateCloseButtonViewMethod2 View = new DelegateCloseButtonViewMethod2();
        public DelegateCloseButtonViewModel()
        {
            View.DataContext = this;           
            CloseWindow = new DelegateCommand(_CloseWindow, CanExecute);

            //Add null Event
            CloseWindowEvent = BaseEvent;
            //or
            CloseWindowEvent = () =>
            {
                return;
            };
          
        }
        private void BaseEvent()
        {
            return;
        }

    }
}
