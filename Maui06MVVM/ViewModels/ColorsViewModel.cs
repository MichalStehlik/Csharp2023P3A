using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui06MVVM.ViewModels
{
    internal class ColorsViewModel : INotifyPropertyChanged
    {
        private int _red;
        private int _green;
        private int _blue;
        private Color _color;

        public ColorsViewModel()
        {
            Red = 100;
            Green = 100;
            Blue = 200;
        }

        public int Red
        {
            get
            {
                return _red;
            }
            set
            {
                _red = value;
                OnPropertyChanged();
                OnPropertyChanged("Color");
                OnPropertyChanged("Luminance");
                OnPropertyChanged("Brightness");
            }
        }
        public int Green
        {
            get
            {
                return _green;
            }
            set
            {
                _green = value;
                OnPropertyChanged();
                OnPropertyChanged("Color");
                OnPropertyChanged("Luminance");
                OnPropertyChanged("Brightness");
            }
        }

        public int Blue
        {
            get
            {
                return _blue;
            }
            set
            {
                _blue = value;
                Color2 = new Color(Red, value, Green);
                OnPropertyChanged();
                OnPropertyChanged("Color");
                OnPropertyChanged("Luminance");
                OnPropertyChanged("Brightness");
            }
        }

        public Color Color2
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }
        public int Luminance
        {
            get { return (int)(0.2126 * Red + 0.7152 * Green + 0.0722 * Blue); }
        }

        public int Brightness
        {
            get { return (Red + Green + Blue) / 3; }
        }

        public Color Color
        {
            get { return new Color(Red, Green, Blue); }
        }

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
