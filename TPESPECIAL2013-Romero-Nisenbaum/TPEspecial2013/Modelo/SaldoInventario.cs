using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class SaldoInventario
    {
        int idsaldo;
        DateTime fechadesde;
        DateTime fechahasta;
        int valorinventario;
        string unidad;

        public SaldoInventario()
        { 
        }

        public int IdSaldo
        {
            get { return idsaldo; }
            set { idsaldo = value; }
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
        
        public int ValorInventario
        {
            get { return valorinventario; }
            set { valorinventario = value; }
        }

        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }
    }
}
