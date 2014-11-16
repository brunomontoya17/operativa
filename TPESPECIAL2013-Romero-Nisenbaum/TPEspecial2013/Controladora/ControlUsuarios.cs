using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using Modelo;

namespace Controladora
{
    public class ControlUsuarios
    {
        DaoUsuarios users = DaoUsuarios.InstanciaUnica;

        static Usuario UsuarioLogeado = null;

        static public Usuario WhoIsLogged()
        {
            return UsuarioLogeado;
        } 

        public static void LogOut()
        {
            UsuarioLogeado = null;
        }

        public void LogIn(string usuario, string pass)
        {
            if (UsuarioLogeado == null)
                UsuarioLogeado = users.AutenticarUsuario(usuario, pass);
            else
            {
                Usuario oUsuarioAux = users.AutenticarUsuario(usuario,pass);

                if (oUsuarioAux.Nombre != UsuarioLogeado.Nombre)
                    throw new Exception("Existe una sesion en suspension");
            }

        }
    }
}
