using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class ModeloPeriodoTiempoFijo:ModeloBase
    {
        decimal DiasTranscurridosentreRevisiones=31;

        decimal NivelServicioDeseado = 0.99m;

        public ModeloPeriodoTiempoFijo()
        { 
        }

        public decimal T
        {
            get { return DiasTranscurridosentreRevisiones; }
            set { DiasTranscurridosentreRevisiones = value; }
        }

        public decimal CalcularDesviacionEstandar(int desv)
        {
            decimal total1 = T + L;
            double raiz = System.Math.Sqrt(Convert.ToDouble(total1));

            decimal total2 = Convert.ToDecimal(raiz) * desv;

            return total2;
            
        }

        public decimal CalcularZ(int desv,decimal demprom)
        { 
            decimal te_mas_ele=DiasTranscurridosentreRevisiones+L;
            decimal raiz=Convert.ToDecimal(System.Math.Sqrt(Convert.ToDouble(te_mas_ele)));

            decimal zimba=raiz*desv;

            decimal primera=demprom*DiasTranscurridosentreRevisiones*(1-NivelServicioDeseado);

            decimal ezeta=primera/zimba;

            decimal zeta=0;

            if(ezeta>1)
            {
                decimal num1=4.5m-ezeta;

                decimal num2=-4.5m+num1;

                zeta=num2;
            }
            else
            {
                decimal num1=1.083m-ezeta;

                decimal num2=-1m+num1;

                zeta=num2;
            }

            return zeta;
        }

        public decimal CalcularCantidadUnidadesReorden(Producto p,int desviacion)
        {
            decimal te_mas_ele=DiasTranscurridosentreRevisiones+L;
            double cantidadpedida = Convert.ToDouble(te_mas_ele);
            decimal raiz=Convert.ToDecimal(System.Math.Sqrt(cantidadpedida));

            decimal zimba=raiz*desviacion;

            decimal z = CalcularZ(desviacion, p.DemandaPromedioDiaria);

            decimal parte1 = (p.DemandaPromedioDiaria * (DiasTranscurridosentreRevisiones + L)) + (z * zimba);

            decimal q = 0;

            if (parte1 <= p.Stock)
            {
                q = (p.Stock - parte1);
            }
            else
            {
                q = (parte1 - p.Stock);
            }
            
            return q;
        }
    }
}
