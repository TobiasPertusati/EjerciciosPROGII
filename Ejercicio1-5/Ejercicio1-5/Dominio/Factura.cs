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




        public override string ToString()
        {
            return $"{NroFacura} | {Fecha} | {FormaPago} | {Cliente}";
        }
    }
}
