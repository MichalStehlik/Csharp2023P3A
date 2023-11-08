using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui05Binding.Models
{
    public class Person: INotifyPropertyChanged
    {
        private string _firstname;
        private int _age;

        public string Firstname
        {
            get => _firstname; 
            set { _firstname = value; OnPropertyChanged(); }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
