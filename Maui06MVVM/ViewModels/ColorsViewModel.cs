using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui06MVVM.ViewModels
{
    internal class ColorsViewModel: INotifyPropertyChanged
    {
        private int _red;
        private int _green;
        private int _blue;

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
                OnPropertyChanged();
            }
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
