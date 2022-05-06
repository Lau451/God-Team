using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoGrupal
{
    internal class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public int Edad { get; set; }

        public Cliente(string Nombre, string Apellido, string Email, int Dni, int Edad)
        {
            this.Nombre = Nombre;

            this.Apellido = Apellido;

            this.Email = Email;

            this.Dni = Dni;

            this.Edad = Edad;
        }

        public Cliente ModCliente(string Nombre, string Apellido, string Email, int Dni, int Edad)
        { 
            this.Nombre = Nombre;

            this.Apellido = Apellido;

            this.Email = Email;

            this.Dni = Dni;

            this.Edad = Edad;

            return this;
        }
    }
}
