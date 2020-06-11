using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionBlanco.Models
{
    public class CALCULOS
    {
        static AEROPUERTOS Aeropuertos = new AEROPUERTOS();

        public static double CalcularDistancia(AEROPUERTO p1, AEROPUERTO p2)
        {
            double salida = 0;
            double rad_per_grad = Math.PI / 180;
            double rkm = 6371;

            double dLatitud_rad = (p2.LATITUD - p1.LATITUD) * rad_per_grad;
            double dLongitud_rad = (p2.LONGITUD - p1.LONGITUD) * rad_per_grad;

            double latitud1_rad = p1.LATITUD * rad_per_grad;
            double latitud2_rad = p2.LATITUD * rad_per_grad;

            double sinDLatitud = Math.Sin(dLatitud_rad / 2);
            double sinDLongitud = Math.Sin(dLongitud_rad / 2);

            double a = sinDLatitud * sinDLatitud + 
                       Math.Cos(latitud1_rad) * Math.Cos(latitud2_rad) *
                       sinDLongitud * sinDLongitud;
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return rkm * c;
        }

        public static double CalcularCO2(double distancia)
        {
            return distancia * 0.32 / 1000;
        }

        public static int CalcularValor(double CO2)
        {
            return Convert.ToInt32(CO2 * 80);
        }

        public static int ValorFinal(AEROPUERTO p1, AEROPUERTO p2)
        {
            return CalcularValor(CalcularCO2(CalcularDistancia(p1, p2)));
        }
    }
}