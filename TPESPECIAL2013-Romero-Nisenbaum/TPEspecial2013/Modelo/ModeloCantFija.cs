using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class ModeloCantFija:ModeloBase
    {
        decimal CostoColocacacionPedido=3;
        decimal CostoAnualMantenimientoyAlmacenamientoporUnidad=1;
        int cantidaddiasanuales=365;

        public ModeloCantFija() 
        {
        }

        public decimal S
        {
            get { return CostoColocacacionPedido; }
            set { CostoColocacacionPedido = value; }
        }

        public decimal H
        {
            get { return CostoAnualMantenimientoyAlmacenamientoporUnidad; }
            set { CostoAnualMantenimientoyAlmacenamientoporUnidad = value; }
        }

        public int CantidadDiasAnuales
        {
            get { return cantidaddiasanuales; }
            set { cantidaddiasanuales = value; }
        }

        public decimal CalcularCostoAnualTotal(Producto p)
        {
            decimal c = p.Precio;

            decimal D=p.DemandaPromedioDiaria*365;

            decimal Q=CalcularCantidadUnidadesReorden(p);

            decimal cat = (D * c) + ((D / Q) * CostoColocacacionPedido) + ((Q / 2) * CostoAnualMantenimientoyAlmacenamientoporUnidad);

            return cat;
        }

        public decimal CalcularPuntoReorden(decimal demandadiaria)
        {
            decimal diaria =demandadiaria * L;

            return diaria;
        }

        public decimal CalcularCantidadUnidadesReorden(Producto p)
        {
            decimal demandaanual=p.DemandaPromedioDiaria*365;

            decimal primero=2*demandaanual*CostoColocacacionPedido;

            decimal total = primero / CostoAnualMantenimientoyAlmacenamientoporUnidad;

            return Convert.ToDecimal(System.Math.Sqrt(Convert.ToDouble(total)));
        }
    }
}
