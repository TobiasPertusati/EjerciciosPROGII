using Ejercicio1_5.MODELOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.DATA.Interfaces
{
    public interface IArticuloRepository
    {
        List<Articulo> ObtenerTodos(); 
        Articulo ObtenerPorId(int id);
        bool Guardar(Articulo articulo);
        bool Eliminar(int id);



    }

}
