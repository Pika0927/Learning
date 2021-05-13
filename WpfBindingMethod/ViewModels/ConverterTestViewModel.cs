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
    public class ConverterTestViewModel : ViewModelBase
    {
        private string _TextValue1;

        public string TextValue1
        {
            get { return _TextValue1; }
            set
            {
                _TextValue1 = value;
                OnPropertyChanged();
            }
        }
        private double _Max;

        public double Max
        {
            get { return _Max; }
            set
            {
                _Max = value;
                OnPropertyChanged();
            }
        }
        private double _Min;

        public double Min
        {
            get { return _Min; }
            set
            {
                _Min = value;
                OnPropertyChanged();
            }
        }

        public ConverterTest View = new ConverterTest();
        public ConverterTestViewModel()
        {
            Min = -100;
            Max = 200;
            TextValue1 = "100";
            View.DataContext = this;
        }
    }
}
