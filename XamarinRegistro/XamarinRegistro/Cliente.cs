using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace XamarinRegistro
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Codigo { get; set;}
        public string Nombre { get; set;}
        public string Direccion { get; set;}
        public string Telefono { get; set;}
        public string Email { get; set;}
        public string Dni { get; set;}

        public Cliente()
        {
        }
    }
}
