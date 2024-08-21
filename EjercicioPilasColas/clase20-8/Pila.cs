using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase20_8
{
    public class Pila : IColleccion
    {
        public Pila(int tam)
        {
            this.Contador = 0;
            ElementosPila = new object[tam];
        }
        public int Contador { get; set; }
        public object[]? ElementosPila { get; set; }


        // LAST IN FIRST OUT
        public bool agregar(object obj)
        {
            ElementosPila[Contador] = obj;
            Contador++;
            return true;
        }

        public bool estaVacia()
        {
            return Contador > 0 ? false : true;
        }

        public object extraer()
        {
            object obj = ElementosPila[Contador - 1];
            ElementosPila[Contador - 1] = null;
            Contador --;
            return obj;
        }

        // EL PRIMERO DE LA PILA ES EL ITEM QUE ESTA EN LA CIMA
        public object primero()
        {
            object obj = null;
            if (!estaVacia())
            {
                obj = ElementosPila[Contador - 1];
            }
            return obj;
               
        }
    }
}
