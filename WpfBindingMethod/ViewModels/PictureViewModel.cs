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
using System.Windows.Media.Imaging;

namespace WpfBindingMethod.ViewModels
{
    class PictureViewModel : ViewModelBase
    {
        #region Binding Data

        private BitmapImage _Image1;
        public BitmapImage Image1
        {
            get { return _Image1; }
            set
            {
                _Image1 = value;
                OnPropertyChanged();
            }
        }
        private BitmapImage _Image2;
        public BitmapImage Image2
        {
            get { return _Image2; }
            set
            {
                _Image2 = value;
                OnPropertyChanged();
            }
        }
        private BitmapImage _Image3;
        public BitmapImage Image3
        {
            get { return _Image3; }
            set
            {
                _Image3 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ICommand
        public ICommand LeftPicture { get; set; }

        private bool CanLeftPicture(object param)
        {
            return true;
        }
        public void _LeftPicture(object param)
        {
            PathIndex--;
            Image1 = BitmapLoad(PicturePaths[PathIndex % 7], 200);
            Image2 = BitmapLoad(PicturePaths[(PathIndex + 1) % 7], 200);
            Image3 = BitmapLoad(PicturePaths[(PathIndex + 2) % 7], 200);

        }
        public ICommand RightPicture { get; set; }

        private bool CanRightPicture(object param)
        {
            return true;
        }
        public void _RightPicture(object param)
        {
            PathIndex++;
            Image1 = BitmapLoad(PicturePaths[PathIndex % 7], 200);
            Image2 = BitmapLoad(PicturePaths[(PathIndex + 1) % 7], 200);
            Image3 = BitmapLoad(PicturePaths[(PathIndex + 2) % 7], 200);
        }
        #endregion
        private string BasePath = @"C:\Projects\WpfBindingMethod\WpfBindingMethod\File\";
        private List<string> PicturePaths = new List<string>();
        private int PathIndex = 0;
        public PictureViewModel()
        {
            LeftPicture = new DelegateCommand(_LeftPicture, CanLeftPicture);
            RightPicture = new DelegateCommand(_RightPicture, CanRightPicture);
            PicturePaths.Add(BasePath + "1-1.jpg");
            PicturePaths.Add(BasePath + "1-2.jpg");
            PicturePaths.Add(BasePath + "1-3.jpg");
            PicturePaths.Add(BasePath + "1-4.jpg");
            PicturePaths.Add(BasePath + "1-5.jpg");
            PicturePaths.Add(BasePath + "1-6.jpg");
            PicturePaths.Add(BasePath + "1-7.jpg");
            Image1 = BitmapLoad(PicturePaths[PathIndex], 200);
            Image2 = BitmapLoad(PicturePaths[PathIndex + 1], 200);
            Image3 = BitmapLoad(PicturePaths[PathIndex + 2], 200);

        }
        public BitmapImage BitmapLoad(string path, int width)
        {
            BitmapImage Image = new BitmapImage();
            try
            {
                Image.BeginInit();
                Image.UriSource = new Uri(path);
                Image.CacheOption = BitmapCacheOption.OnLoad;
                Image.DecodePixelWidth = width;
                Image.EndInit();
            }
            catch (Exception)
            {
            }
            return Image;
        }

    }
}
