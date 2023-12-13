using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui08Colections.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _x;

        public MainViewModel()
        {
            X = Random.Shared.Next(100);
        }

        public int X
        { 
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
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
