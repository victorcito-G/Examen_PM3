using Examen_3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Examen_3.ViewModels
{
    public class ArticulosMVVM
    {
        readonly SQLiteAsyncConnection _database;

        public ArticulosMVVM(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pagos>().Wait();
        }

        public ArticulosMVVM()
        {
        }

        public Task<List<Pagos>> GetTaskAsync()
        {
            return _database.Table<Pagos>().OrderByDescending(x => x.Fecha).ToListAsync();
        }

        
        public Task<int> SaveTaskAsync(Pagos taskModel)
        {

            if (taskModel.Id_pago != 0)
            {
                return _database.UpdateAsync(taskModel);
            }
            else
            {
                return _database.InsertAsync(taskModel);
            }

        }

        public Task<int>UpdateTaskAsync(Pagos pagos)
        {
            return _database.UpdateAsync(pagos);
        }

        public Task<int> deleteAsync(Pagos pagos)
        {
            return _database.DeleteAsync(pagos);
        }

        public Task<Pagos> GetItemAsync(int personId)
        {
            return _database.Table<Pagos>().Where(i => i.Id_pago == personId).FirstOrDefaultAsync();
        }

        public Task<Pagos> DeleteItemAsync(int personId)
        {
            return _database.Table<Pagos>().Where(i => i.Id_pago == personId).FirstOrDefaultAsync();
        }


    }
}