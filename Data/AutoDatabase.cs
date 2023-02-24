using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProgramareRevizie.Models;

namespace ProgramareRevizie.Data
{
    public class AutoDatabase
    {
        //Aceasta clasa va contine cod pentru crearea, citirea, srierea si stergerea datelor
        //Utilizam API-r SQLite asincrone pentru a pune operatiile pe baza de date in thread-uri de background
        //Constructorul a estei clase ia ca si argument calea catre fisierul de tip baza de date 
        // => aceasta cale este furnizata de clasa App in pasul urmator

        readonly SQLiteAsyncConnection _database;
        public AutoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programare>().Wait();
            _database.CreateTableAsync<Serviciu>().Wait();
            _database.CreateTableAsync<ListaServicii>().Wait();
        }

        public Task<int> SaveServiciuAsync(Serviciu Serviciu)
        {
            if (Serviciu.ID != 0)
            {
                return _database.UpdateAsync(Serviciu);
            }
            else
            {
                return _database.InsertAsync(Serviciu);
            }
        }
        public Task<int> DeleteServiciuAsync(Serviciu Serviciu)
        {
            return _database.DeleteAsync(Serviciu);
        }
        public Task<List<Serviciu>> GetServiciusAsync()

        {
            return _database.Table<Serviciu>().ToListAsync();
        }
    
       public Task<List<Programare>> GetProgramaresAsync()
        {
            return _database.Table<Programare>().ToListAsync();
        }
        public Task<Programare> GetProgramareAsync(int id)
        {
            return _database.Table<Programare>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveProgramareAsync(Programare slist)
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
        public Task<int> DeleteProgramareAsync(Programare slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> DeleteListaServiciiAsync(ListaServicii listp)
        {
            return _database.DeleteAsync(listp);
        }

        public Task<List<ListaServicii>> GetListaServiciis()
        {
            return _database.QueryAsync<ListaServicii>("select * from ListaServicii");
        }


        public Task<int> SaveListaServiciiAsync(ListaServicii listp)
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
        public Task<List<Serviciu>> GetListaServiciisAsync(int Programareid)
        {
            return _database.QueryAsync<Serviciu>(
            "select P.ID, P.Description from Serviciu P"
            + " inner join ListaServicii LP"
            + " on P.ID = LP.ServiciuID where LP.ProgramareID = ?",
            Programareid);
        }

    }

}
