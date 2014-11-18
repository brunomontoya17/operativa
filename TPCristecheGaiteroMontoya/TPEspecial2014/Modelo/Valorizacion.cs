using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Valorizacion
    {
        int idvalorizacion;

        decimal valor;

        decimal porcentaje;

        DateTime fechavalorizacion;

        public Valorizacion()
        { 
        }

        public int IdValorizacion
        {
            get { return idvalorizacion; }
            set { idvalorizacion = value; }
        }

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public decimal Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

        public DateTime FechaValorizacion
        {
            get { return fechavalorizacion; }
            set { fechavalorizacion = value; }
        }

    }
}
