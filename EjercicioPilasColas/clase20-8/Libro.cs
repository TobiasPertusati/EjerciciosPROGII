using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase20_8
{
    public class Libro
    {
        public Libro(int isbn, string titulo)
        {
            this.ISBN = isbn;
            this.Titulo = titulo;
        }
        public int ISBN { get; set; }
        public string Titulo { get; set; }

        public override string ToString()
        {
            return $"{ISBN} | {Titulo}";
        }

    }
}
