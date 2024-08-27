using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Dominio
{
    public class DetalleFacura
    {
        public int IdDetalle {  get; set; }
        public Factura? Factura { get; set; }
        public Articulo? Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
