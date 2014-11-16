using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class DemandaProductoMensual
    {
        int iddemanda;
        DateTime fechadesde;
        DateTime fechahasta;
        int valordemanda;
        string unidad;

        public DemandaProductoMensual()
        {
        }

        public int IdDemanda
        {
            get { return iddemanda; }
            set { iddemanda = value; }
        }

        public DateTime FechaDesde
        {
            get { return fechadesde; }
            set { fechadesde = value; }
        }

        public DateTime FechaHasta
        {
            get { return fechahasta; }
            set { fechahasta = value; }
        }

        public int ValorDemanda
        {
            get { return valordemanda; }
            set { valordemanda = value; }
        }

        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }
    }
}
