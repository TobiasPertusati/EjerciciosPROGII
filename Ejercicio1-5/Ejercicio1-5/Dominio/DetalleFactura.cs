using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Dominio
{
    public class DetalleFactura
    {
        public Articulo? Articulo { get; set; }
        public int Cantidad { get; set; }

        public double SubTotal()
        {
            return Cantidad * Articulo.PrecioUnitario;
        }

        public override string ToString()
        {
            return $"|{Cantidad,6}{" ",6}|{" ",4}{Articulo.Nombre,15}{" ",4}|{Articulo.PrecioUnitario,10}{" ",5}|{" ",3}{SubTotal(),5}{" ",2}|\n" +
                   $"|{"---------------------------------------------------------------"}|\n";
        }
    }
}
