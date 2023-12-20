using Maui08Colections.Models;
using SQLite;

namespace Maui08Colections.Data
{
    internal class ShoppingDatabase
    {
        private SQLiteAsyncConnection _database;

        public ShoppingDatabase()
        {

        }
        private async Task Init()
        {
            if (_database is not null)
                return;
            string path = Path.Combine(FileSystem.AppDataDirectory, "ShoppingList.sqlite");
            _database = new SQLiteAsyncConnection(
                path,
                SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache);
            var result = await _database.CreateTableAsync<ShoppingItem>();
        }

        public async Task<List<ShoppingItem>> GetItemsAsync()
        {
            await Init();
            return await _database.Table<ShoppingItem>().ToListAsync();
        }
        public async Task<List<ShoppingItem>> GetItemsNotDoneAsync()
        {
            await Init();
            return await _database.Table<ShoppingItem>().Where(t => t.Obtained).ToListAsync();
        }

        public async Task<ShoppingItem> GetItemAsync(int id)
        {
            await Init();
            return await _database.Table<ShoppingItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(ShoppingItem item)
        {
            await Init();
            if (item.Id != 0)
                return await _database.UpdateAsync(item);
            else
                return await _database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(ShoppingItem item)
        {
            await Init();
            return await _database.DeleteAsync(item);
        }
    }
}
