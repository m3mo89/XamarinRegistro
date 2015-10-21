using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinRegistro
{
    public class ClienteDB
    {
        private SQLiteConnection _sqlconnection;

        public ClienteDB()
        {
            //Getting conection and Creating table
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlconnection.CreateTable<Cliente>();
        }
 
        //Get all clients
        public IEnumerable<Cliente> GetClientes()
        {
            return (from t in _sqlconnection.Table<Cliente>() select t).ToList();
        }
 
        //Get specific client
        public Cliente GetCliente(int id)
        {
            return _sqlconnection.Table<Cliente>().FirstOrDefault(t => t.Id == id);
        }
 
        //Delete specific client
        public void DeleteCliente(int id)
        {
            _sqlconnection.Delete<Cliente>(id);
        }
 
        //Add new client to DB
        public void AddCliente(Cliente client)
        {
            _sqlconnection.Insert(client);
        }

		public bool IsRepeat(string codigo, string nombre, string dni){
			bool repetido = true;
			Cliente cliente;
			cliente = _sqlconnection.Table<Cliente>().FirstOrDefault(t => t.Codigo == codigo || t.Nombre == nombre ||  t.Dni == dni);

			if (cliente == null)
				repetido = false;

			return repetido;
		}
    }
}
