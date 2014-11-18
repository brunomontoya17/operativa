using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoUsuarios
    {
        Conexion Cn = new Conexion();

		static DaoUsuarios instanciaUnica = null;
		private DaoUsuarios ( ) { }
		public static DaoUsuarios InstanciaUnica
		{
			get
			{
				if ( instanciaUnica == null ) instanciaUnica = new DaoUsuarios( );
				return instanciaUnica;
			}
		}

		public Usuario AutenticarUsuario ( string usuario, string pass )
		{
			Usuario oUsuario = Buscar(usuario,pass);

            if (oUsuario != null)
            {
                if (oUsuario.Nombre == usuario && oUsuario.Password == pass)
                {
                    return oUsuario;
                }
            }

			return null;
		}

        public void AgregarUsuario(Usuario oNuevo)
        {
            string cmdText = "insert into Usuario(nombre,pass,email) values('" +

            oNuevo.Nombre + "','" + oNuevo.Password + "','" + oNuevo.Email + "')";

            Cn.ActualizarBD(cmdText);
        }

		public Usuario Buscar(string user,string pass)
		{
            string cmdText = "select * from Usuario";

            DataTable DT = Cn.LeerDatos(cmdText);

            foreach (DataRow dr in DT.Rows)
            {
                if (Convert.ToString(dr["nombre"]) == user && Convert.ToString(dr["pass"]) == pass)
                {
                    Usuario u = new Usuario();

                    u.IdUsuario = Convert.ToInt32(dr["idusuario"]);

                    u.Nombre = Convert.ToString(dr["nombre"]);

                    u.Password = Convert.ToString(dr["pass"]);

                    u.Email = Convert.ToString(dr["email"]);

                    return u;
                }
            }

            return null;
		}

    }
}
