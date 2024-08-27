using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain
{
    public class Product
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return $"Codigo : {Codigo} | Nombre : {Nombre} | Precio : {Precio} | Stock: {Stock}";
        }
    }
}
