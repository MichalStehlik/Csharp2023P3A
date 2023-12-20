using Maui08Colections.Data;
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
        private ShoppingDatabase _db;
        public Command CreateCommand { get; set; }
        public Command ReloadCommand { get; set; }
        public Command<ShoppingItem> DeleteCommand { get; set; }
        public Command<ShoppingItem> UpdateCommand { get; set; }

        public MainViewModel()
        {
            X = Random.Shared.Next(100);
            _db = new ShoppingDatabase();
            //Items.Add(new ShoppingItem { Id = 1, Name="Borůvky", Amount = 12});
            //Items.Add(new ShoppingItem { Id = 2, Name = "Chléb", Amount = 1 });
            Task.Run(() => { LoadAsync(); });
            CreateCommand = new Command(
            async () =>
            {
                //Items.Add(new ShoppingItem { Id = Items.Count + 1, Name = Item.Name, Amount = Item.Amount, Obtained = Item.Obtained });
                //Item.Obtained = false;
                //Item.Name = default;
                //Item.Amount = default;
                await StoreItemAsync(new ShoppingItem { Name = Item.Name, Amount = Item.Amount, Obtained = Item.Obtained });
                await LoadAsync();
            },
            () =>
            {
                return true;
            });
            ReloadCommand = new Command(
            async () =>
            {
                await LoadAsync();
            },
            () =>
            {
                return true;
            });
            DeleteCommand = new Command<ShoppingItem>(
            async (item) =>
            {
                await DeleteItemAsync(item);
                await LoadAsync();
            },
            (item) =>
            {
                return item is not null;
            });
            UpdateCommand = new Command<ShoppingItem>(
            async (item) =>
            {
                await StoreItemAsync(item);
                await LoadAsync();
            },
            (item) =>
            {
                return item is not null;
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
            set { _selected = value; OnPropertyChanged(); DeleteCommand.ChangeCanExecute(); }
        }

        private async Task LoadAsync()
        {
            var items = await _db.GetItemsAsync();
            Items.Clear();
            foreach(var it in items)
            {
                Items.Add(it);
            }
            Selected = null;
        }

        private async Task<int> StoreItemAsync(ShoppingItem item)
        {
            return await _db.SaveItemAsync(item);
        }

        private async Task<int> DeleteItemAsync(ShoppingItem item)
        {
            return await _db.DeleteItemAsync(item);
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
