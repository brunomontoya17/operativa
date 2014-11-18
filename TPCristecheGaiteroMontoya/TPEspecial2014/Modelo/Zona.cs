using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Zona
    {
        int idzona;

        string descripcion;

        List<Producto> listado;

        decimal porcentaje;

        public Zona()
        {
            listado = new List<Producto>();
        }

        public Zona(string d, decimal p)
        {
            descripcion = d;

            porcentaje = p;
        }

        public List<Producto> ListadoDeProductos
        {
            get { return listado; }
            set { listado = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int IdZona
        {
            get { return idzona; }
            set { idzona = value; }
        }

        public decimal Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

    }
}
