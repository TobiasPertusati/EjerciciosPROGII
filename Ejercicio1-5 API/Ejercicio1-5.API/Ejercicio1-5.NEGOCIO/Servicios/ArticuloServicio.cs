using Ejercicio1_5.DATA.Interfaces;
using Ejercicio1_5.DATA.Repository;
using Ejercicio1_5.MODELOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.NEGOCIO.Servicios
{
    public class ArticuloServicio : IAplicacion
    {
        private IArticuloRepository _repository;
        public ArticuloServicio()
        {
            _repository = new ArticuloRepositoryADO();
        }

        public List<Articulo> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }
        public Articulo ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public bool Guardar(Articulo articulo)
        {
           return _repository.Guardar(articulo); 
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
