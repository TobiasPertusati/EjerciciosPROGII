using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Dominio
{
    public class FormaPago
    {
        public int IdFormaPago { get; set; }
        public string? Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
