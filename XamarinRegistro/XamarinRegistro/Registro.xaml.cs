using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinRegistro
{
    public partial class Registro : ContentPage
    {
        public ClienteDB _clientedb;
        public Cliente cliente;
        public Registro()
        {
            InitializeComponent();
            
        }

        public void adddata(object s, EventArgs args)
        {
            cliente = new Cliente();
            _clientedb = new ClienteDB();

			if ( String.IsNullOrEmpty(codigo.Text) ||  String.IsNullOrEmpty(nombre.Text) ||  String.IsNullOrEmpty(direccion.Text)
				||  String.IsNullOrEmpty(telefono.Text) ||  String.IsNullOrEmpty(email.Text) ||  String.IsNullOrEmpty(dni.Text)
				||  telefono.TextColor == Color.Red || email.TextColor == Color.Red) {
				DisplayAlert("ERROR","Todos los campos son obligatorios (Los marcados en rojo no tienen formato correcto)", "Aceptar");
			} else {
				if (_clientedb.IsRepeat (codigo.Text, nombre.Text, dni.Text)) {
					DisplayAlert ("ERROR", "El cliente ya existe o esta repitiendo codigo, nombre o dni", "Aceptar");
				} else {
					cliente.Codigo = codigo.Text;
					cliente.Nombre = nombre.Text;
					cliente.Direccion = direccion.Text;
					cliente.Telefono = telefono.Text;
					cliente.Email = email.Text;
					cliente.Dni = dni.Text;            

					_clientedb.AddCliente (cliente);

					DisplayAlert ("OK", "Registro agregado correctamente", "Aceptar");
				}
			}
        }        
    }
}