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
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ListProduct>().Wait();
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
        public Task<int> SaveProductAsync(Product product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }
        public Task<int> SaveListProductAsync(ListProduct listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Product>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Product>(
            "select P.ID, P.Descriere from Product P"
            + " inner join ListProduct LP"
            + " on P.ID = LP.ProductID where LP.RezervareID = ?",
            shoplistid);
        }
        public Task<int> DeleteListProductAsync(ListProduct listp)
        {
            return _database.DeleteAsync(listp);
        }

        public Task<List<ListProduct>> GetListProducts()
        {
            return _database.QueryAsync<ListProduct>("select * from ListProduct");
        }
    }
}
    

