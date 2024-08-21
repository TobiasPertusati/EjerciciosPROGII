using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase20_8
{
    public class Cola : IColleccion
    {
        public Cola()
        {
            ElementosCola = new List<object> { };
        }
        public List<object>? ElementosCola { get; set; }


        //FIFO EL PRIMERO QUE ENTRA ES EL PRIMERO QUE SALE 
        public bool agregar(object obj)
        {
            bool res = true;
            if (ElementosCola != null)
                this.ElementosCola.Add(obj);
            else
                res = false;
            return res;
        }

        public bool estaVacia()
        {
            bool res = true;
            if (ElementosCola != null && ElementosCola.Count > 0)
                res = false;
            return res;
        }

        public object extraer()
        {
            object obj = primero();
            ElementosCola.Remove(obj);
            return obj;
        }

        public object primero()
        {
            return ElementosCola.First();
        }
    }
}
