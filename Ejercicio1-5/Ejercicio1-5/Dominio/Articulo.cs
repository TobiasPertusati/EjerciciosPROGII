using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Dominio
{
    public class Articulo
    {
        //public int IdArticulo { get; set; }
        public string? Nombre { get; set; }
        public double PrecioUnitario { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
