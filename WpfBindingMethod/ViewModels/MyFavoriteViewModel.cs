using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoraMVVM.Helper;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WpfBindingMethod.Views;
using System.Windows.Media;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;
using SD = System.Drawing;
using System.Windows.Controls;

namespace WpfBindingMethod.ViewModels
{
    class MyFavoriteViewModel : ViewModelBase
    {
        #region BindingData
        private List<Point> FavoriteIconPos = new List<Point>() {
            new Point(25,145),
            new Point(95,145),
            new Point(165,145),
            new Point(235,145)
        };
        private Point _ObjectPos = new Point(0, 0);
        public Point ObjectPos
        {
            get { return _ObjectPos; }
            set
            {
                _ObjectPos = value;
                OnPropertyChanged();
            }
        }
        private Brush _FavoriteBrush1;
        public Brush FavoriteBrush1
        {
            get { return _FavoriteBrush1; }
            set
            {
                _FavoriteBrush1 = value;
                OnPropertyChanged();
            }
        }
        private Brush _FavoriteBrush2;
        public Brush FavoriteBrush2
        {
            get { return _FavoriteBrush2; }
            set
            {
                _FavoriteBrush2 = value;
                OnPropertyChanged();
            }
        }
        private Brush _FavoriteBrush3;
        public Brush FavoriteBrush3
        {
            get { return _FavoriteBrush3; }
            set
            {
                _FavoriteBrush3 = value;
                OnPropertyChanged();
            }
        }
        private Brush _FavoriteBrush4;
        public Brush FavoriteBrush4
        {
            get { return _FavoriteBrush4; }
            set
            {
                _FavoriteBrush4 = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public MyFavorite View = new MyFavorite();
        Stopwatch RemoveStopWatch = new Stopwatch();
        public MyFavoriteViewModel()
        {
            View.DataContext = this;
            StartPosition = new Point(0, 0);
            OriPosition = new Point(0, 0);
        }
        #region MoveEvent
        private bool IsDragging;
        private Point StartPosition;
        private Point OriPosition;
        #region AddItem
        public void AddMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                IsDragging = true;
                var DraggableElement = sender as UIElement;
                var ClickPosition = e.GetPosition(View);
                var MyTransform = DraggableElement.RenderTransform as TranslateTransform;
                StartPosition.X = ClickPosition.X - MyTransform.X;
                StartPosition.Y = ClickPosition.Y - MyTransform.Y;
                OriPosition.X = MyTransform.X;
                OriPosition.Y = MyTransform.Y;
                PreTransX = 0;
                PreTransY = 0;
                DraggableElement.CaptureMouse();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Down" + ee.ToString()); 
            }
        }

        public void AddMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                IsDragging = false;
                var DraggableElement = sender as Label;
                DraggableElement.ReleaseMouseCapture();
                Point CurrentPosition = e.GetPosition(View as UIElement);
                var MyTransform = DraggableElement.RenderTransform as TranslateTransform;
                MyTransform.X = OriPosition.X;
                MyTransform.Y = OriPosition.Y;
                SetLabelBackGround(IsMyFavorite(CurrentPosition), DraggableElement.Background);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Up" + ee.ToString());
            }
        }
        double PreTransX;
        double PreTransY;
        public void AddMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var DraggableElement = sender as UIElement;
                if (IsDragging && DraggableElement != null)
                {
                    Point CurrentPosition = e.GetPosition(View as UIElement);
                    var MyTransform = DraggableElement.RenderTransform as TranslateTransform;
                    PreTransX = CurrentPosition.X - StartPosition.X;
                    PreTransY = CurrentPosition.Y - StartPosition.Y;
                    MyTransform.X = PreTransX / 2;
                    MyTransform.Y = PreTransY / 2;
                    //ObjectPos = new Point(CurrentPosition.X, CurrentPosition.Y);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Move" + ee.ToString());
            }
        }

        private int IsMyFavorite(Point CurrentPosition)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Math.Abs(CurrentPosition.X - FavoriteIconPos[i].X) < 20 &&
                    Math.Abs(CurrentPosition.Y - FavoriteIconPos[i].Y) < 20)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
        #region RemoveItem
        public void RemoveMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                IsDragging = true;
                var DraggableElement = sender as UIElement;
                var ClickPosition = e.GetPosition(View);
                var MyTransform = DraggableElement.RenderTransform as TranslateTransform;
                StartPosition.X = ClickPosition.X - MyTransform.X;
                StartPosition.Y = ClickPosition.Y - MyTransform.Y;
                OriPosition.X = MyTransform.X;
                OriPosition.Y = MyTransform.Y;
                PreTransX = 0;
                PreTransY = 0;
                DraggableElement.CaptureMouse();
                RemoveStopWatch.Reset();
                RemoveStopWatch.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Down" + ee.ToString());
            }
        }

        public void RemoveMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                IsDragging = false;
                var DraggableElement = sender as UIElement;
                DraggableElement.ReleaseMouseCapture();
                Point CurrentPosition = e.GetPosition(View.Parent as UIElement);
                var MyTransform = DraggableElement.RenderTransform as TranslateTransform;
                MyTransform.X = OriPosition.X;
                MyTransform.Y = OriPosition.Y;
                RemoveStopWatch.Stop();
                if (RemoveStopWatch.Elapsed.TotalMilliseconds > 300 && IsRemoveMyFavorite(CurrentPosition, StartPosition))
                {
                    SetLabelBackGround(RemoveItemIndex(StartPosition), new SolidColorBrush(Colors.Transparent));
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Up" + ee.ToString());
            }
        }

        public void RemoveMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var DraggableElement = sender as UIElement;
                if (IsDragging && DraggableElement != null)
                {
                    Point CurrentPosition = e.GetPosition(View.Parent as UIElement);
                    var MyTransform = DraggableElement.RenderTransform as TranslateTransform;
                    PreTransX = CurrentPosition.X - StartPosition.X;
                    PreTransY = CurrentPosition.Y - StartPosition.Y;
                    MyTransform.X = PreTransX / 2;
                    MyTransform.Y = PreTransY / 2;
                    ObjectPos = new Point(CurrentPosition.X, CurrentPosition.Y);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Move" + ee.ToString());
            }
        }
        private bool IsRemoveMyFavorite(Point CurrentPosition, Point StartPoint)
        {
            if (Math.Abs(CurrentPosition.X - StartPoint.X) > 50 ||
                    Math.Abs(CurrentPosition.Y - StartPoint.Y) > 50)
            {
                return true;
            }
            return false;
        }
        private int RemoveItemIndex(Point StartPoint)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Math.Abs(StartPoint.X - FavoriteIconPos[i].X) < 26 &&
                       Math.Abs(StartPoint.Y - FavoriteIconPos[i].Y) < 26)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
        private void SetLabelBackGround(int index, Brush SetColor)
        {
            switch (index)
            {
                case 0:
                    FavoriteBrush1 = SetColor;
                    break;
                case 1:
                    FavoriteBrush2 = SetColor;
                    break;
                case 2:
                    FavoriteBrush3 = SetColor;
                    break;
                case 3:
                    FavoriteBrush4 = SetColor;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
