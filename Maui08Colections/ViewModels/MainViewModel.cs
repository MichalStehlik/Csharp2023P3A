using Maui08Colections.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui08Colections.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ShoppingItem> _items = new ObservableCollection<ShoppingItem>();
        private int _x;
        private ShoppingItem _item = new ShoppingItem();
        private ShoppingItem _selected = new ShoppingItem();
        public Command CreateCommand { get; set; }

        public MainViewModel()
        {
            X = Random.Shared.Next(100);
            Items.Add(new ShoppingItem { Id = 1, Name="Borůvky", Amount = 12});
            Items.Add(new ShoppingItem { Id = 2, Name = "Chléb", Amount = 1 });
            CreateCommand = new Command(
            () =>
            {
                Items.Add(new ShoppingItem { Id = Items.Count + 1, Name = Item.Name, Amount = Item.Amount, Obtained = Item.Obtained });
                Item.Obtained = false;
                Item.Name = default;
                Item.Amount = default;
            },
            () =>
            {
                return true;
            });
        }

        public int X
        { 
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }
        public ObservableCollection<ShoppingItem> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }
        public ShoppingItem Item
        {
            get { return _item; }
            set { _item = value; OnPropertyChanged(); }
        }
        public ShoppingItem Selected
        {
            get { return _selected; }
            set { _selected = value; OnPropertyChanged(); }
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
