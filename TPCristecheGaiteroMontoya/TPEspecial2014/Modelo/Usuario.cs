using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Usuario
    {
        int idusuario;

        string nombre;

        string password;

        string email;

        public Usuario()
        { 
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int IdUsuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
