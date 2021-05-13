using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBindingMethod.Views
{
    /// <summary>
    /// MoveObject.xaml 的互動邏輯
    /// </summary>
    public partial class MoveObject : UserControl
    {
        string X;
        private string myVar;
        public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public MoveObject()
        {
            InitializeComponent();
            MyProperty = AquaX.Text;
            GX.DataContext = this;
        }

        private void ChangePos(object sender, EventArgs e)
        {

        }

        private bool isDragging;
        private Point startPosition;

        private void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            var draggableElement = sender as UIElement;
            var clickPosition = e.GetPosition(this);

            var transform = draggableElement.RenderTransform as TranslateTransform;
            startPosition.X = clickPosition.X - transform.X;    //注意減號
            startPosition.Y = clickPosition.Y - transform.Y;

            draggableElement.CaptureMouse();
        }

        private void grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            var draggableElement = sender as UIElement;
            draggableElement.ReleaseMouseCapture();
        }

        private void grid_MouseMove(object sender, MouseEventArgs e)
        {
            var draggableElement = sender as UIElement;
            if (isDragging && draggableElement != null)
            {
                Point currentPosition = e.GetPosition(this.Parent as UIElement);
                var transform = draggableElement.RenderTransform as TranslateTransform;

                transform.X = currentPosition.X - startPosition.X;
                transform.Y = currentPosition.Y - startPosition.Y;
            }
        }

        #region MoveEvent
        public bool IsDragging;
        public Point StartPosition;

        public void GridMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                IsDragging = true;
                var DraggableElement = sender as UIElement;
                var ClickPosition = e.GetPosition(this);
                var MyTransform = DraggableElement.RenderTransform as TranslateTransform;
                StartPosition.X = ClickPosition.X - MyTransform.X;    //注意減號
                StartPosition.Y = ClickPosition.Y - MyTransform.Y;
                DraggableElement.CaptureMouse();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Down" + ee.ToString());
            }
        }

        public void GridMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                IsDragging = false;
                var draggableElement = sender as UIElement;
                draggableElement.ReleaseMouseCapture();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Up" + ee.ToString());

            }
        }

        public void GridMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var DraggableElement = sender as UIElement;
                if (IsDragging && DraggableElement != null)
                {
                    Point CurrentPosition = e.GetPosition(this.Parent as UIElement);
                    var MyTransform = DraggableElement.RenderTransform as TranslateTransform;
                    MyTransform.X = CurrentPosition.X - StartPosition.X;
                    MyTransform.Y = CurrentPosition.Y - StartPosition.Y;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Move" + ee.ToString());

            }
        }
        #endregion

    }
}
