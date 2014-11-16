using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Producto
    {
        int idproducto;
        int codigobarra;
        string descripcion;
        int stock;
        decimal precio;
        List<DemandaProductoMensual> historialdemanda;
        List<SaldoInventario> historialsaldo;
        List<Valorizacion> historialvalorizaciones;
        decimal demandapromediodiaria = 0;

        public Producto()
        {
            historialdemanda = new List<DemandaProductoMensual>();

            historialsaldo = new List<SaldoInventario>();

            historialvalorizaciones = new List<Valorizacion>();
        }

        public int IdProducto
        {
            get { return idproducto; }
            set { idproducto = value; }
        }

        public int CodigoBarra
        {
            get { return codigobarra; }
            set { codigobarra = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public decimal DemandaPromedioDiaria
        {
            get { return demandapromediodiaria; }
            set { demandapromediodiaria = value; }
        }

        public List<DemandaProductoMensual> HistorialDemanda
        {
            get { return historialdemanda; }
            set { historialdemanda = value; }
        }

        public List<SaldoInventario> HistorialSaldo
        {
            get { return historialsaldo; }
            set { historialsaldo = value; }
        }

        public List<Valorizacion> Historialvalorizaciones
        {
            get { return historialvalorizaciones; }
            set { historialvalorizaciones = value; }
        }
    }
}
