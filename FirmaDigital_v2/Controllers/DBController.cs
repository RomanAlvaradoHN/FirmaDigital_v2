using SQLite;
using FirmaDigital_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaDigital_v2.Controllers {
    public class DBController {

        //DATABASE CONFIGURATION VARIABLES
        //=======================================================================================
        private readonly static string dbFileName = "MyAppDB.db3";

        private readonly SQLiteOpenFlags flags = SQLiteOpenFlags.ReadWrite |
                                                 SQLiteOpenFlags.Create |
                                                 SQLiteOpenFlags.SharedCache;

        private readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);
        //---------------------------------------------------------------------------------------
        private SQLiteAsyncConnection connection;
        //======================================================================================


        public DBController() {
        }



        private async Task Init() {
            if (connection is not null) {
                return;
            }
            connection = new SQLiteAsyncConnection(dbPath, flags);
            await connection.CreateTableAsync<Firmas>();
        }



        //CREATE ==============================================================
        public async Task<int> Insert(Firmas fotoData) {
            await Init();
            return await connection.InsertAsync(fotoData);
        }




        //READ ==============================================================
        public async Task<List<Firmas>> SelectAll() {
            await Init();
            return await connection.Table<Firmas>().ToListAsync();
        }


        public async Task<Firmas> SelectById(int id) {
            await Init();
            return await connection.Table<Firmas>().Where(col => col.Id == id).FirstOrDefaultAsync();
        }




        //UPDATE ==============================================================
        public async Task<int> Update(Firmas fotoData) {
            await Init();
            return await connection.UpdateAsync(fotoData);
        }




        //DELETE ==============================================================
        public async Task<int> Delete(Firmas fotoData) {
            await Init();
            return await connection.DeleteAsync(fotoData);
        }
    }
}