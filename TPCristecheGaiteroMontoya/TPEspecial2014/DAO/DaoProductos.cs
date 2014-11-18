using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DAO
{
    public class DaoProductos
    {
        Conexion Cn = new Conexion();

		static DaoProductos instanciaUnica = null;
		private DaoProductos ( ) { }
		public static DaoProductos InstanciaUnica
		{
			get
			{
				if ( instanciaUnica == null ) instanciaUnica = new DaoProductos( );
				return instanciaUnica;
			}
		}

        public void AgregarProducto(Producto oNuevo)
        {
            string cmdText = "insert into Producto(codigo,descripcion,stock,precio,demandapromediodiaria,zona_id) values(" +

            oNuevo.CodigoBarra + ",'" + oNuevo.Descripcion + "'," + oNuevo.Stock + "," + oNuevo.Precio.ToString("F3", new System.Globalization.CultureInfo("en-US")) + "," + oNuevo.DemandaPromedioDiaria.ToString("F3", new System.Globalization.CultureInfo("en-US")) + ",null)";

            Cn.ActualizarBD(cmdText);
        }

        public void AptualizarPrecioProducto(Producto oNuevo)
        {
            string cmdText = "update Producto set precio=" + oNuevo.Precio.ToString("F3", new System.Globalization.CultureInfo("en-US")) + " where idproducto=" + oNuevo.IdProducto;        

            Cn.ActualizarBD(cmdText);
        }

        public void SetearZona(Producto p, int idzona)
        {
            string cmdText = "update Producto set zona_id=" + idzona + " where idproducto=" + p.IdProducto;

            Cn.ActualizarBD(cmdText);
        }

        public void SetearDemandaPDiaria(Producto p, decimal valor)
        {
            string cmdText = "update Producto set demandapromediodiaria=" + valor.ToString("F3", new System.Globalization.CultureInfo("en-US")) + " where idproducto=" + p.IdProducto;

            Cn.ActualizarBD(cmdText);
        }

        public void AptualizarValorDemanda(DemandaProductoMensual dpm)
        {
            string cmdText = "update DemandaMensual set valor=" + dpm.ValorDemanda + " where iddemanda=" + dpm.IdDemanda;

            Cn.ActualizarBD(cmdText);
        }

        public void AptualizarValorSaldo(SaldoInventario s)
        {
            string cmdText = "update Saldo set valor=" + s.ValorInventario + " where idsaldo=" + s.IdSaldo;

            Cn.ActualizarBD(cmdText);
        }

        public void AgregarDemanda(DemandaProductoMensual dpm, int productoid)
        {
            string cmdText = "insert into DemandaMensual(fechadesde,fechahasta,valor,producto_id,unidad) values('" +

            dpm.FechaDesde.Day + "/" + dpm.FechaDesde.Month + "/" + dpm.FechaDesde.Year + "','" + dpm.FechaHasta.Day + "/" + dpm.FechaHasta.Month + "/" +

            dpm.FechaHasta.Year + "'," + dpm.ValorDemanda + "," + productoid + ",'" + dpm.Unidad + "')";

            Cn.ActualizarBD(cmdText);
        }

        public void AgregarSaldo(SaldoInventario s, int productoid)
        {
            string cmdText = "insert into Saldo(fechadesde,fechahasta,valor,producto_id,unidad) values('" +

            s.FechaDesde.Day + "/" + s.FechaDesde.Month + "/" + s.FechaDesde.Year + "','" + s.FechaHasta.Day + "/" + s.FechaHasta.Month + "/" +

            s.FechaHasta.Year + "'," + s.ValorInventario + "," + productoid + ",'" + s.Unidad + "')";

            Cn.ActualizarBD(cmdText);
        }

        public void AgregarValorizacion(Valorizacion v, int productoid)
        {
            string cmdText = "insert into Valorizaciones(valor,porcentaje,fechavalorizacion,producto_id) values(" + v.Valor.ToString("F3", new System.Globalization.CultureInfo("en-US")) + "," + v.Porcentaje.ToString("F3", new System.Globalization.CultureInfo("en-US")) + ",'" +

            v.FechaValorizacion.Day + "/" + v.FechaValorizacion.Month + "/" + v.FechaValorizacion.Year + "'," + productoid + ")";

            Cn.ActualizarBD(cmdText);
        }

		public Producto Buscar(int Codigo)
		{
            string cmdText = "select * from Producto";

            DataTable DT = Cn.LeerDatos(cmdText);

            foreach (DataRow dr in DT.Rows)
            {
                if (Convert.ToInt32(dr["codigo"]) == Codigo)
                {
                    Producto p = new Producto();

                    p.IdProducto = Convert.ToInt32(dr["idproducto"]);

                    p.CodigoBarra = Convert.ToInt32(dr["codigo"]);

                    p.Descripcion = Convert.ToString(dr["descripcion"]);

                    p.Stock = Convert.ToInt32(dr["stock"]);

                    p.Precio = Convert.ToDecimal(dr["precio"]);

                    p.DemandaPromedioDiaria = Convert.ToDecimal(dr["demandapromediodiaria"]);

                    p.HistorialDemanda = ListarDemandas_Producto(p.IdProducto);

                    p.HistorialSaldo = ListarInventarios_Producto(p.IdProducto);

                    p.Historialvalorizaciones = ListarValorizaciones_Producto(p.IdProducto);

                    return p;
                }
            }

            return null;
		}

        public Zona BuscarZona(string descrip)
        {
            string cmdText = "select * from Zona";

            DataTable DT = Cn.LeerDatos(cmdText);

            foreach (DataRow dr in DT.Rows)
            {
                if (Convert.ToString(dr["descripcion"]) == descrip)
                {
                    Zona z = new Zona();

                    z.IdZona = Convert.ToInt32(dr["idzona"]);

                    z.Descripcion = Convert.ToString(dr["descripcion"]);

                    z.Porcentaje = Convert.ToDecimal(dr["porcentaje"]);

                    z.ListadoDeProductos = ListarProductoxZona(z.IdZona);

                    return z;
                }
            }

            return null;
        }

        public List<Zona> ListarZona()
        {
            string cmdText = "select * from Zona";

            DataTable DT = Cn.LeerDatos(cmdText);

            List<Zona> Lista=new List<Zona>();

            foreach (DataRow dr in DT.Rows)
            {

                Zona z = new Zona();

                z.IdZona = Convert.ToInt32(dr["idzona"]);

                z.Descripcion = Convert.ToString(dr["descripcion"]);

                z.Porcentaje = Convert.ToDecimal(dr["porcentaje"]);

                z.ListadoDeProductos = ListarProductoxZona(z.IdZona);

                Lista.Add(z);

            }

            return Lista;
        }
        public List<Producto> ListarProductoxZona(int idzona)
        {
            string cmdText = "select * from Producto where zona_id=" + idzona;

            DataTable DT = Cn.LeerDatos(cmdText);

            List<Producto> Lista = new List<Producto>();

            foreach (DataRow dr in DT.Rows)
            {
                Producto p = new Producto();

                p.IdProducto = Convert.ToInt32(dr["idproducto"]);

                p.CodigoBarra = Convert.ToInt32(dr["codigo"]);

                p.Descripcion = Convert.ToString(dr["descripcion"]);

                p.Stock = Convert.ToInt32(dr["stock"]);

                p.Precio = Convert.ToDecimal(dr["precio"]);

                p.DemandaPromedioDiaria = Convert.ToDecimal(dr["demandapromediodiaria"]);

                p.HistorialDemanda = ListarDemandas_Producto(p.IdProducto);

                p.HistorialSaldo = ListarInventarios_Producto(p.IdProducto);

                p.Historialvalorizaciones = ListarValorizaciones_Producto(p.IdProducto);

                Lista.Add(p);
            }

            return Lista;
        }

        public List<DemandaProductoMensual> ListarDemandas_Producto(int Id)
        {
            string cmdText = "select * from DemandaMensual where producto_id=" + Id;

            List<DemandaProductoMensual> Lista=new List<DemandaProductoMensual>();

            DataTable DT = Cn.LeerDatos(cmdText);

            foreach (DataRow dr in DT.Rows)
            {
                DemandaProductoMensual dpm = new DemandaProductoMensual();

                dpm.IdDemanda = Convert.ToInt32(dr["iddemanda"]);

                dpm.FechaDesde = Convert.ToDateTime(dr["fechadesde"]);

                dpm.FechaHasta = Convert.ToDateTime(dr["fechahasta"]);

                dpm.ValorDemanda = Convert.ToInt32(dr["valor"]);

                dpm.Unidad = Convert.ToString(dr["unidad"]);

                Lista.Add(dpm);
            }

            return Lista;
        }

        public List<SaldoInventario> ListarInventarios_Producto(int Id)
        {
            string cmdText = "select * from Saldo where producto_id=" + Id;

            List<SaldoInventario> Lista = new List<SaldoInventario>();

            DataTable DT = Cn.LeerDatos(cmdText);

            foreach (DataRow dr in DT.Rows)
            {
                SaldoInventario s = new SaldoInventario();

                s.IdSaldo = Convert.ToInt32(dr["idsaldo"]);

                s.FechaDesde = Convert.ToDateTime(dr["fechadesde"]);

                s.FechaHasta = Convert.ToDateTime(dr["fechahasta"]);

                s.ValorInventario = Convert.ToInt32(dr["valor"]);

                s.Unidad = Convert.ToString(dr["unidad"]);

                Lista.Add(s);
            }

            return Lista;
        }

        public List<Valorizacion> ListarValorizaciones_Producto(int Id)
        {
            string cmdText = "select * from Valorizaciones where producto_id=" + Id;

            List<Valorizacion> Lista = new List<Valorizacion>();

            DataTable DT = Cn.LeerDatos(cmdText);

            foreach (DataRow dr in DT.Rows)
            {
                Valorizacion v = new Valorizacion();

                v.IdValorizacion = Convert.ToInt32(dr["idvalorizacion"]);

                v.Valor = Convert.ToDecimal(dr["valor"]);

                v.Porcentaje = Convert.ToDecimal(dr["porcentaje"]);

                v.FechaValorizacion = Convert.ToDateTime(dr["fechavalorizacion"]);

                Lista.Add(v);
            }

            return Lista;
        }

        public List<Producto> ListarProductos()
        {
            string cmdText = "select * from Producto";

            List<Producto> Lista = new List<Producto>();

            DataTable DT = Cn.LeerDatos(cmdText);

            foreach (DataRow dr in DT.Rows)
            {
                Producto p = new Producto();

                p.IdProducto = Convert.ToInt32(dr["idproducto"]);

                p.CodigoBarra = Convert.ToInt32(dr["codigo"]);

                p.Descripcion = Convert.ToString(dr["descripcion"]);

                p.Stock = Convert.ToInt32(dr["stock"]);

                p.Precio = Convert.ToDecimal(dr["precio"]);

                p.DemandaPromedioDiaria = Convert.ToDecimal(dr["demandapromediodiaria"]);

                p.HistorialDemanda = ListarDemandas_Producto(p.IdProducto);

                p.HistorialSaldo = ListarInventarios_Producto(p.IdProducto);

                p.Historialvalorizaciones = ListarValorizaciones_Producto(p.IdProducto);

                Lista.Add(p);

            }

            return Lista;
        }

    }
}
