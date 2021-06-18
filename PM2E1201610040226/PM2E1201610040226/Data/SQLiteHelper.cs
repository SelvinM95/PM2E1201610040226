using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using PM2E1201610040226.Modelos;

namespace PM2E1201610040226.Data
{
   public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Ubicacion>().Wait();
        }

        //Guardar Datos
        public Task<int> SaveUbicacionAsync(Ubicacion ubicacion)
        {
            if (ubicacion.id != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }

        //Muestar todos los datos de la BD
        public Task<List<Ubicacion>> GetUbicacionAsync()
        {
            return db.Table<Ubicacion>().ToListAsync();
        }

        //Muestar todos los datos de la BD por ID
        public Task<Ubicacion> GetUbicacionByIdAsync(int id)
        {
            return db.Table<Ubicacion>().Where(a => a.id == id).FirstOrDefaultAsync();
        }

        //Borrar datos
        public Task<int> DeleteUbicacionAsync(Ubicacion ubicacion)
        {
            return db.DeleteAsync(ubicacion);
        }


    }
}
