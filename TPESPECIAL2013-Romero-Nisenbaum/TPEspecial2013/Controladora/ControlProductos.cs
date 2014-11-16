using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using DAO;

namespace Controladora
{
    public class ControlProductos
    {
        DaoProductos d_productos = DaoProductos.InstanciaUnica;

        public bool ProcesarCodigo(object codigo,object descripcion, object precio,object stock)
        {
            string des;
            decimal prec;
            int st;
            int codi;

            if (!decimal.TryParse(precio.ToString(), out prec))
                return false;

            if (descripcion == null)
                return false;

            if (!int.TryParse(stock.ToString(), out st))
                return false;

            if (!int.TryParse(codigo.ToString(), out codi))
                return false;

            des = descripcion.ToString();               

            //ARRANCA EL MAPPEO 

            List<Producto> productos = d_productos.ListarProductos();

            //si el producto es nuevo lo agrego

            if (d_productos.Buscar(codi) == null)
            {
                Producto p = new Producto();

                p.CodigoBarra = codi;

                p.Descripcion = des;

                p.Precio = prec;

                p.Stock = st;

                d_productos.AgregarProducto(p);

                return true;
            }
            else
            {
                Producto p = d_productos.Buscar(codi);

                p.Precio = prec;

                d_productos.AptualizarPrecioProducto(p);
            }
          
            return false;
        }

        public bool ProcesarArchivoDemandas(object codigo, object descripcion, object cantidad, object unidad, DateTime desde, DateTime hasta)
        {
            string des,uni;
            int cant,codi;

            if (!int.TryParse(cantidad.ToString(),out cant))
                return false;

            if (descripcion == null)
                return false;

            if (unidad==null)
                return false;

            if (!int.TryParse(codigo.ToString(), out codi))
                return false;

            des = descripcion.ToString();
            uni = unidad.ToString();
            //ARRANCA EL MAPPEO 

            Producto p=d_productos.Buscar(codi);

            if(p!=null)
            {
                List<DemandaProductoMensual> demandas = d_productos.ListarDemandas_Producto(p.IdProducto);

                foreach (DemandaProductoMensual d in demandas)
                {
                    if (d.FechaDesde.Day==desde.Day && d.FechaDesde.Month==desde.Month && d.FechaDesde.Year==desde.Year
                    && d.FechaHasta.Day == hasta.Day && d.FechaHasta.Month == hasta.Month && d.FechaHasta.Year == hasta.Year)
                    {
                        d.ValorDemanda = cant;

                        d_productos.AptualizarValorDemanda(d);

                        return true;
                    }
                }

                DemandaProductoMensual dpm = new DemandaProductoMensual();

                dpm.FechaDesde = desde;

                dpm.FechaHasta = hasta;

                dpm.ValorDemanda = cant;

                dpm.Unidad = uni;

                d_productos.AgregarDemanda(dpm, p.IdProducto);

                return true;
            }

            return false;
        }

        public bool ProcesarArchivoSaldos(object codigo, object descripcion, object cantidad, object unidad, DateTime desde, DateTime hasta)
        {
            string des,uni;
            int cant,codi;

            if (!int.TryParse(cantidad.ToString(),out cant))
                return false;

            if (descripcion == null)
                return false;

            if (unidad==null)
                return false;

            if (!int.TryParse(codigo.ToString(), out codi))
                return false;

            des = descripcion.ToString();
            uni = unidad.ToString();
            //ARRANCA EL MAPPEO 

            Producto p=d_productos.Buscar(codi);

            if(p!=null)
            {
                List<SaldoInventario> saldos = d_productos.ListarInventarios_Producto(p.IdProducto);

                foreach (SaldoInventario s in saldos)
                {
                    if (s.FechaDesde.Day==desde.Day && s.FechaDesde.Month==desde.Month && s.FechaDesde.Year==desde.Year
                    && s.FechaHasta.Day == hasta.Day && s.FechaHasta.Month == hasta.Month && s.FechaHasta.Year == hasta.Year)
                    {
                        s.ValorInventario = cant;

                        d_productos.AptualizarValorSaldo(s);

                        return true;
                    }
                }

                SaldoInventario sal = new SaldoInventario();

                sal.FechaDesde = desde;

                sal.FechaHasta = hasta;

                sal.ValorInventario = cant;

                sal.Unidad = uni;

                d_productos.AgregarSaldo(sal, p.IdProducto);

                return true;
            }

            return false;
        }

        public DemandaProductoMensual BuscarUltimaDemanda(Producto p)
        {
            int ultMes=0;

            DemandaProductoMensual ultima = null;

            foreach (DemandaProductoMensual dpm in p.HistorialDemanda)
            {
                if (ultima == null)
                {
                    ultima = dpm;

                    ultMes = ultima.FechaHasta.Month;
                }
                else
                {
                    if (dpm.FechaHasta.Month > ultMes)
                    {
                        ultima = dpm;

                        ultMes = dpm.FechaHasta.Month;
                    }
                }
            }

            return ultima;
        }

        public SaldoInventario BuscarUltimaSaldoInventario(Producto p)
        {
            int ultMes = 0;

            SaldoInventario ultima = null;

            foreach (SaldoInventario s in p.HistorialSaldo)
            {
                if (ultima == null)
                {
                    ultima = s;

                    ultMes = ultima.FechaHasta.Month;
                }
                else
                {
                    if (s.FechaHasta.Month > ultMes)
                    {
                        ultima = s;

                        ultMes = s.FechaHasta.Month;
                    }
                }
            }

            return ultima;
        }

        public Valorizacion BuscarUltimaValorizacion(Producto p)
        {
            int ultMes = 0;

            Valorizacion ultima = null;

            foreach (Valorizacion v in p.Historialvalorizaciones)
            {
                if (ultima == null)
                {
                    ultima = v;

                    ultMes = v.FechaValorizacion.Month;
                }
                else
                {
                    if (v.FechaValorizacion.Month > ultMes)
                    {
                        ultima = v;

                        ultMes = v.FechaValorizacion.Month;
                    }
                }
            }

            return ultima;
        }

        public decimal CalcularTotalValorizaciones()
        {
            decimal TotalValorizaciones = 0;

            List<Producto> ListaProductos = d_productos.ListarProductos();

            foreach (Producto p in ListaProductos)
            {
                DemandaProductoMensual d = BuscarUltimaDemanda(p);

                SaldoInventario s = BuscarUltimaSaldoInventario(p);

                int DemandaReal = (d.ValorDemanda - s.ValorInventario) * 12;

                TotalValorizaciones += DemandaReal * p.Precio;
            }

            return TotalValorizaciones;
        }

        public Boolean AgregarValorizaciones(decimal TotalValorizaciones)
        {
            List<Producto> ListaProductos = d_productos.ListarProductos();

            foreach (Producto p in ListaProductos)
            {
                DemandaProductoMensual d = BuscarUltimaDemanda(p);

                SaldoInventario s = BuscarUltimaSaldoInventario(p);

                if (d != null && s != null)
                {
                    Valorizacion v = BuscarUltimaValorizacion(p);

                    decimal DemandaReal = (d.ValorDemanda - s.ValorInventario) * 12;

                    decimal diaria = (DemandaReal / 365m);

                    if (v == null)
                    {
                        Valorizacion val = new Valorizacion();

                        val.FechaValorizacion = DateTime.Today;

                        val.Valor = p.Precio * DemandaReal;

                        decimal porct = val.Valor / TotalValorizaciones;

                        val.Porcentaje = porct;

                        d_productos.AgregarValorizacion(val, p.IdProducto);

                        d_productos.SetearDemandaPDiaria(p, diaria);

                    }
                    else if (DateTime.Today.Month > v.FechaValorizacion.Month)
                    {
                        Valorizacion val = new Valorizacion();

                        val.FechaValorizacion = DateTime.Today;

                        val.Valor = p.Precio * DemandaReal;

                        decimal val_val = val.Valor;

                        decimal porct = (val_val / TotalValorizaciones);

                        val.Porcentaje = porct;

                        d_productos.AgregarValorizacion(val, p.IdProducto);

                        d_productos.SetearDemandaPDiaria(p, diaria);

                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    throw new Exception("No hay Informacion de demanda y saldo de inventario de los productos");
                }
                
            }

            return true;
        }

        public Producto BuscarxVal(decimal val)
        {
            List<Producto> Lista=d_productos.ListarProductos();

            foreach (Producto p in Lista)
            {
                Valorizacion v = BuscarUltimaValorizacion(p);

                if (v.Porcentaje == val)
                {
                    return p;
                }
            }

            return null;
        }

        public void ProcesarZonas()
        {
            decimal porct_a=Convert.ToDecimal(0.74);

            decimal porct_b=Convert.ToDecimal(0.21);

            decimal porct_c = Convert.ToDecimal(0.05);

            Zona a = d_productos.BuscarZona("A");

            Zona b = d_productos.BuscarZona("B");

            Zona c = d_productos.BuscarZona("C");

            decimal TotalVal = CalcularTotalValorizaciones();

            if (AgregarValorizaciones(TotalVal))
            {
                List<Producto> Lista = d_productos.ListarProductos();

                List<Valorizacion> ListaVal = new List<Valorizacion>();

                decimal suma = 0;

                foreach (Producto p in Lista)
                {
                    Valorizacion v = BuscarUltimaValorizacion(p);

                    ListaVal.Add(v);
                }

                ListaVal.OrderBy(x => x.Porcentaje);

                foreach (Valorizacion v in ListaVal)
                {
                    if (suma < porct_a)
                    {
                        suma += v.Porcentaje;

                        Producto oprod = BuscarxVal(v.Porcentaje);

                        a.ListadoDeProductos.Add(oprod);

                        d_productos.SetearZona(oprod, a.IdZona);
                    }
                    else if (suma >= porct_a && suma < porct_b)
                    {
                        suma += v.Porcentaje;

                        Producto oprod = BuscarxVal(v.Porcentaje);

                        b.ListadoDeProductos.Add(oprod);

                        d_productos.SetearZona(oprod, b.IdZona);
                    }
                    else
                    {
                        suma += v.Porcentaje;

                        Producto oprod = BuscarxVal(v.Porcentaje);

                        c.ListadoDeProductos.Add(oprod);

                        d_productos.SetearZona(oprod, c.IdZona);
                    }
                }

            }

        }

        public List<Producto> ListarProductos()
        {
            return d_productos.ListarProductos();
        }

        public Zona BuscarZona_Producto(Producto p)
        {
            Zona a = d_productos.BuscarZona("A");

            Zona b = d_productos.BuscarZona("B");

            Zona c = d_productos.BuscarZona("C");

            foreach (Producto prod in a.ListadoDeProductos)
            {
                if (prod.IdProducto == p.IdProducto)
                {
                    return a;
                }
            }

            foreach (Producto prod2 in b.ListadoDeProductos)
            {
                if (prod2.IdProducto == p.IdProducto)
                {
                    return b;
                }
            }

            foreach (Producto prod3 in c.ListadoDeProductos)
            {
                if (prod3.IdProducto == p.IdProducto)
                {
                    return c;
                }
            }

            return null;
        }

        public List<Zona> ListarZonas()
        {
            return d_productos.ListarZona();
        }
    }

}
