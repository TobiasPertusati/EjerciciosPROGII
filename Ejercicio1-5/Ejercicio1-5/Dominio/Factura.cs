using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Dominio
{
    public class Factura
    {
        public int NroFacura { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago? FormaPago { get; set; }
        public string? Cliente { get; set; }

        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();

        public double TotalFactura()
        {
            double total = 0;
            foreach (DetalleFactura d in Detalles)
            {
                total += d.SubTotal();
            }
            return total;
        }
        public override string ToString()
        {
            string res =
                   $"|{"---------------------------------------------------------------"}|\n" +
                   $"|FAC:{NroFacura,2}|{" ",1}{Fecha,10}{" ",1}|{FormaPago,15}{" ",3}|{Cliente,15}{" ",1}|\n" +
                   $"|{"---------------------------------------------------------------"}|\n" +
                   $"| TOTAL : {TotalFactura()}{" ",50}|\n" +
                   $"|{"---------------------------------------------------------------"}|\n" +
                   $"|{" ",2}{"CANTIDAD"}{" ",2}|{"ARTICULO",15}{" ",8}|{"PRECIO UNITARIO",10}|{" ",1}{"SUBTOTAL"}{" ",1}|\n" +
                   $"|{"---------------------------------------------------------------"}|\n";
            foreach (DetalleFactura d in Detalles)
            {
                res += d.ToString();
            }
            return res;

        }
    }
}
