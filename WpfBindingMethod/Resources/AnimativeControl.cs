using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace WpfBindingMethod.Resources
{
    class AnimativeControl
    {

    }
    public class CirProgressBarLabel : Label
    {
        public CirProgressBarLabel() : base() {

            Point1 = new Point(0, 0);
        }
        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }
        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            nameof(Progress), typeof(double), typeof(CirProgressBarLabel), new PropertyMetadata(0.0, ProgressPropertyCallBack));

        public Point Point1
        {
            get { return (Point)GetValue(Point1Property); }
            set { SetValue(Point1Property, value); }
        }
        public static readonly DependencyProperty Point1Property = DependencyProperty.Register(
            nameof(Point1), typeof(Point), typeof(CirProgressBarLabel), new PropertyMetadata(new Point(0, 0)));

        public Point Point2
        {
            get { return (Point)GetValue(Point2Property); }
            set { SetValue(Point2Property, value); }
        }
        public static readonly DependencyProperty Point2Property = DependencyProperty.Register(
            nameof(Point2), typeof(Point), typeof(CirProgressBarLabel), new PropertyMetadata(new Point(0, 0)));

        public Point Point3
        {
            get { return (Point)GetValue(Point3Property); }
            set { SetValue(Point3Property, value); }
        }
        public static readonly DependencyProperty Point3Property = DependencyProperty.Register(
            nameof(Point3), typeof(Point), typeof(CirProgressBarLabel), new PropertyMetadata(new Point(0, 0)));

        public Point Point4
        {
            get { return (Point)GetValue(Point4Property); }
            set { SetValue(Point4Property, value); }
        }
        public static readonly DependencyProperty Point4Property = DependencyProperty.Register(
            nameof(Point4), typeof(Point), typeof(CirProgressBarLabel), new PropertyMetadata(new Point(0, 0)));

        public static void ProgressPropertyCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            var LabelTmp = sender as CirProgressBarLabel;
            if (LabelTmp != null)
            {
                try
                {
                    double Height = LabelTmp.Height;
                    double Width = LabelTmp.Width;
                    double Progress = LabelTmp.Progress;
                    double Px;
                    double Py;
                    Progress = Progress * 90 / 100;
                    Px = Width - Math.Cos(Math.PI * Progress / 180.0) * Width;
                    Py = Height - Math.Sin(Math.PI * Progress / 180.0) * Height;
                    LabelTmp.Point1 = new Point(Px, Py);
                }
                catch (Exception)
                {
                    LabelTmp.Point1 = new Point(0, 0);
                }
            }
        }
    }

    public class RecProgressBarLabel : Label
    {
        public RecProgressBarLabel() : base() { }

        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }
        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            nameof(Progress), typeof(double), typeof(RecProgressBarLabel), new PropertyMetadata(0.0, ProgressPropertyCallBack));

        public double BarLength
        {
            get { return (double)GetValue(BarLengthProperty); }
            set { SetValue(BarLengthProperty, value); }
        }
        public static readonly DependencyProperty BarLengthProperty = DependencyProperty.Register(
            nameof(BarLength), typeof(double), typeof(RecProgressBarLabel), new PropertyMetadata(0.0));

        public static void ProgressPropertyCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var LabelTmp = sender as RecProgressBarLabel;
            if (LabelTmp != null)
            {
                try
                {
                    double Width = LabelTmp.Width;
                    double Progress = LabelTmp.Progress;
                    LabelTmp.BarLength = Progress * Width / 100;
                }
                catch (Exception)
                {
                    LabelTmp.BarLength = 0;
                }
            }
        }
    }
}
