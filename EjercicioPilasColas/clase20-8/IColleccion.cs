using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace clase20_8
{
    public interface IColleccion
    {
        //        estaVacia() : devuelve true si la colección está vacía y false en caso contrario.
        public bool estaVacia();
        //extraer(): devuelve y elimina el primer elemento de la colección.
        public object extraer();
        //        primero(): devuelve el primer elemento de la colección.
        public object primero();
        //añadir(): añade un objeto por el extremo que corresponda, y devuelve true si
        public bool agregar(object obj);
        //se ha añadido y false en caso contrario.



    }
}
