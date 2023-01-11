using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using Proiect_Mobile.Models;

namespace Proiect_Mobile.Data
{
   public  class RezervareDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RezervareDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Rezervare>().Wait();
        }
        public Task<List<Rezervare>> GetRezervareAsync()
        {
            return _database.Table<Rezervare>().ToListAsync();
        }
        public Task<Rezervare> GetRezervareAsync(int id)
        {
            return _database.Table<Rezervare>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRezervareAsync(Rezervare slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteRezervareAsync(Rezervare slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
