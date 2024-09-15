using Ejercicio1_5.MODELOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.NEGOCIO.Servicios
{
    public interface IAplicacion
    {
        public List<Articulo> ObtenerTodos();

        public Articulo ObtenerPorId(int id);

        public bool Guardar(Articulo articulo);

        public bool Eliminar(int id);

    }
}
