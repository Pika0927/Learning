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

namespace WpfBindingMethod.ViewModels
{
    public class ColorPickerViewModel : ViewModelBase
    {
        #region BindingData
        private Brush _TextBackGround1;
        public Brush TextBackGround1
        {
            get { return _TextBackGround1; }
            set
            {
                _TextBackGround1 = value;
                OnPropertyChanged();
            }
        }
        private Brush _TextBackGround2;

        public Brush TextBackGround2
        {
            get { return _TextBackGround2; }
            set
            {
                _TextBackGround2 = value;
                OnPropertyChanged();
            }
        }
        private string _ColorString1;

        public string ColorString1
        {
            get { return _ColorString1; }
            set
            {
                _ColorString1 = value;
                OnPropertyChanged();
                TextBackGround1 = MyColorConverter(value);
            }
        }
        private string _ColorString2;
        public string ColorString2
        {
            get { return _ColorString2; }
            set
            {
                _ColorString2 = value;
                OnPropertyChanged();
                TextBackGround2 = MyColorConverter(value);
            }
        }
        private string _ColorString3;

        public string ColorString3
        {
            get { return _ColorString3; }
            set
            {
                _ColorString3 = value;
                OnPropertyChanged();
            }
        }
        private int _NijiLenth;

        public int NijiLenth
        {
            get { return _NijiLenth; }
            set
            {
                _NijiLenth = value;
                OnPropertyChanged();
            }
        }
        private Point _PathPoint;

        public Point PathPoint
        {
            get { return _PathPoint; }
            set
            {
                _PathPoint = value;
                OnPropertyChanged();
            }
        }
        private Point _NijiCenter;
        public Point NijiCenter
        {
            get { return _NijiCenter; }
            set
            {
                _NijiCenter = value;
                OnPropertyChanged();
            }
        }
        private Point _NijiCenter2;
        public Point NijiCenter2
        {
            get { return _NijiCenter2; }
            set
            {
                _NijiCenter2 = value;
                OnPropertyChanged();
            }
        }
        private Point _NijiCenter3;
        public Point NijiCenter3
        {
            get { return _NijiCenter3; }
            set
            {
                _NijiCenter3 = value;
                OnPropertyChanged();
            }
        }
        private int _WifiX;

        public int WifiX
        {
            get { return _WifiX; }
            set
            {
                _WifiX = value;
                OnPropertyChanged();
            }
        }
        private int _WifiY;

        public int WifiY
        {
            get { return _WifiY; }
            set
            {
                _WifiY = value;
                OnPropertyChanged();
            }
        }
        private double _CirProgress;

        public double CirProgress
        {
            get { return _CirProgress; }
            set
            {
                _CirProgress = value;
                OnPropertyChanged();
            }
        }
        private GeometryGroup _BorderClips = new GeometryGroup();

        public GeometryGroup BorderClips
        {
            get { return _BorderClips; }
            set
            {
                _BorderClips = value;
                OnPropertyChanged();
            }
        }

        private Point _MoveCir;

        public Point MoveCir
        {
            get { return _MoveCir; }
            set { _MoveCir = value;
                OnPropertyChanged();
            }
        }
        private double _KniefAngle;

        public double KniefAngle
        {
            get { return _KniefAngle; }
            set { _KniefAngle = value;
                OnPropertyChanged();
            }
        }

        private double _GoogleAngle;

        public double GoogleAngle
        {
            get { return _GoogleAngle; }
            set { _GoogleAngle = value;
                OnPropertyChanged();
                
            }
        }
        #endregion
        

        [DllImport("shlwapi.dll")]
        public static extern int ColorHLSToRGB(int H, int L, int S);
        public ColorPickerTest View;

        Task RainbowTask;
        public bool AllStop = true;
        public double NijiPercentage = 50;
        DispatcherTimer _timer = new DispatcherTimer();

        private int Count = 0;
        public ColorPickerViewModel()
        {
            View = new ColorPickerTest();
            View.DataContext = this;
            ColorString2 = "#FF000000";
            BorderClips.FillRule = FillRule.Nonzero;
            DoAnimation();
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += _timer_Tick;
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            if(Count > 100)
            {
                BorderClips.Children.Clear();
                RectangleGeometry rec = new RectangleGeometry();
                rec.Rect = new Rect(0, 0,150,150);
                BorderClips.Children.Add(rec);
                return;
            }
            Count++;
            SetClip();
        }
        #region Event
        /// <summary>
        /// Start animetion
        /// </summary>
        public void Rainbow1Start()
        {
            if (AllStop)
            {
                Count = 0;
                BorderClips.Children.Clear();
                _timer.Start();
                RainbowTask = new Task(() =>
                {
                    while (true)
                    {
                        DoAnimation();
                        NijiPercentage++;
                        NijiPercentage %= 101;
                        SpinWait.SpinUntil(() => false, 20);
                        if (AllStop)
                        {
                            return;
                        }
                    }
                });
                AllStop = false;
                RainbowTask.Start();

            }
        }
        /// <summary>
        /// Stop animetion
        /// </summary>
        public void Rainbow1Stop()
        {
            _timer.Stop();
            AllStop = true;
        }
        #endregion

        #region Animation
        private void DoAnimation()
        {
            FillLength(NijiPercentage, 250);
            FillCir(NijiPercentage, 90);
            FillColor(NijiPercentage);
            NijiCenter3 = ChangeCirCenter(NijiPercentage, 50, 200);
            NijiCenter2 = ChangeCirCenter((NijiPercentage + 1.5) % 101, 50, 200);
            NijiCenter = ChangeCirCenter((NijiPercentage + 3.5) % 101, 50, 200);
            SetMoveCir(NijiPercentage);
            CirProgress = NijiPercentage;
            FillWifi(NijiPercentage);
            Knief(NijiPercentage);
        }
        private void FillLength(double Percentage, int Length)
        {
            Percentage = Percentage * Length / 100;
            NijiLenth = (int)Percentage;
        }
        private void FillCir(double Percentage, int FullAng)
        {
            double Px;
            double Py;
            Percentage = Percentage * FullAng / 100;
            Px = 150 - Math.Cos(Math.PI * Percentage / 180.0) * 150;
            Py = 150 - Math.Sin(Math.PI * Percentage / 180.0) * 150;
            PathPoint = new Point(Px, Py);
        }
        private void FillColor(double Percentage)
        {
            int Niji = 0;
            Percentage = Percentage * 240 / 100;
            byte[] NijiByte = new byte[4];
            Niji = ColorHLSToRGB((int)Percentage, 140, 220);
            NijiByte = BitConverter.GetBytes(Niji);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, new Action(() =>
            {
                ColorString1 = String.Format("#FF{0}{1}{2}", NijiByte[2].ToString("X2"), NijiByte[1].ToString("X2"), NijiByte[0].ToString("X2"));
            }));
        }
        private Point ChangeCirCenter(double Percentage, double R, double Width)
        {
            double Px;
            double Py;
            Percentage %= 20;
            Percentage = Percentage * 360 / 20;
            Px = Width / 2 + Math.Cos(Math.PI * Percentage / 180.0) * R;
            Py = Width / 2 + Math.Sin(Math.PI * Percentage / 180.0) * R;
            return new Point(Px, Py);
        }
        private void FillWifi(double Percentage)
        {
            Percentage = Percentage / 10;
            Percentage = Percentage % 5;
            WifiX = (int)Percentage * 25;
            WifiY = WifiX;
        }
        private void SetClip()
        {
            Random Rng = new Random(Guid.NewGuid().GetHashCode());
            int x = Rng.Next(1, 150);
            int y = Rng.Next(1, 150);
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new Point((double)x, (double)y);
            myEllipseGeometry.RadiusX = 20;
            myEllipseGeometry.RadiusY = 20;
            BorderClips.Children.Add(myEllipseGeometry);
        }
        private void SetMoveCir(double Percentage)
        {
            double x = Percentage * 150 / 100;
            double y = 150 * Math.Sin(Math.PI * Percentage / 180.0);
            MoveCir = new Point(x, y);
        }
        private void Knief(double Percentage)
        {
            double AngleTmp;
            AngleTmp = Percentage % 20;
            if (AngleTmp > 9)
            {
                AngleTmp = 260 + (AngleTmp-10) * 5;
            }
            else
            {
                AngleTmp = 310- AngleTmp * 5;
            }
            KniefAngle = AngleTmp;
            GoogleAngle = Percentage * 3.6;

        }
        #endregion

        #region Converter
        public SolidColorBrush MyColorConverter(string ColorString)
        {
            try
            {
                return new SolidColorBrush(Color.FromArgb(
                byte.Parse(ColorString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(ColorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(ColorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber),
                byte.Parse(ColorString.Substring(7, 2), System.Globalization.NumberStyles.HexNumber)));
            }
            catch (Exception)
            {
                return new SolidColorBrush(Colors.White);
            }
        }
        #endregion
    }
}
