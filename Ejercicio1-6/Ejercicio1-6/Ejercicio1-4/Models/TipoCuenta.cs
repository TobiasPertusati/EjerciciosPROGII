using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Models
{
    public class TipoCuenta
    {
        public int? IdTipoCuenta { get; set; }
        public string? Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
