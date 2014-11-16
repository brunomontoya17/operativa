using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class Conexion
    {
        SqlConnection cn = new SqlConnection("Data Source=USUARIO-PC;Initial Catalog=invop;Integrated Security=True");
        

        public void Conectar()
        {
            if (cn.State == ConnectionState.Closed)

                cn.Open();

            else
                throw new Exception("La Conexion ya se Encuentra Abierta");
        }

        public void desconectar()
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
            else
                throw new Exception("La Conexion ya se Encuentra Cerrada");

        }

        public DataTable LeerDatos(string cmdtext)
        {
            DataTable dt = new DataTable();

            try
            {

                SqlCommand cmd = new SqlCommand(cmdtext, cn);

                Conectar();

                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
            }
            catch (Exception ex) { }

            finally
            {

                desconectar();
            }

            return dt;
        }

        public void ActualizarBD(string cmdtext)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(cmdtext, cn);

                Conectar();

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { }

            finally { desconectar(); }
        }
    }
}
