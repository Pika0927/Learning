using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Input;
using SoraMVVM.Helper;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WpfBindingMethod.Views;
using System.Drawing;
using Microsoft.Expression.Interactivity.Layout;

namespace WpfBindingMethod.ViewModels
{
    public class MoveObjectViewModel : ViewModelBase
    {
        public MoveObject View = new MoveObject();
        private double _GridX;

        public double GridX
        {
            get { return _GridX; }
            set
            {
                _GridX = value;
                OnPropertyChanged();
            }
        }

        private double _GridY;

        public double GridY
        {
            get { return _GridY; }
            set
            {
                _GridY = value;
                OnPropertyChanged();
            }
        }
        private string _TextBlock1Text;

        public string TextBlock1Text
        {
            get { return _TextBlock1Text; }
            set
            {
                _TextBlock1Text = value;
                OnPropertyChanged();
            }
        }
        private double _BX;
        public double BX
        {
            get { return _BX; }
            set
            {
                _BX = value;
                OnPropertyChanged();
            }
        }
        private double _BY;
        public double BY
        {
            get { return _BY; }
            set
            {
                _BY = value;
                OnPropertyChanged();
            }
        }


        public delegate void CheckPosDelegete();
        private CheckPosDelegete CheckPos;
        public MoveObjectViewModel()
        {
            Action CheckBlockPos = () =>
            {
                while (true)
                {
                    //if (GridX > 100 && GridX < 110)
                    //{
                    //    if (GridY > 100 && GridY < 110)
                    //    {
                    //        GridX = 105;
                    //        GridY = 105;
                    //        TextBlock1Text = "Bingo!";
                    //        break;
                    //    }
                    //}
                    SpinWait.SpinUntil(() => false, 100);
                }
            };
            BY = 300;
            BX = 50;
            View.DataContext = this;
            Task CheckPosTask = new Task(CheckBlockPos);
            CheckPosTask.Start();
        }
        private void GetPos(object sender, MouseEventArgs args)
        {
            //if (GridX > 100 && GridX < 110)
            //{
            //    if (GridY > 100 && GridY < 110)
            //    {
            //        GridX = 105;
            //        GridY = 105;
            //        TextBlock1Text = "Bingo!";
            //    }
            //}
        }

    }
}
