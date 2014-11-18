using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public abstract class ModeloBase
    {
        decimal TiempoEntrega;

        public ModeloBase()
        {
            TiempoEntrega = 5;
        }

        public decimal L
        {
            get { return TiempoEntrega; }
            set { TiempoEntrega = value; }
        }

    }
}
