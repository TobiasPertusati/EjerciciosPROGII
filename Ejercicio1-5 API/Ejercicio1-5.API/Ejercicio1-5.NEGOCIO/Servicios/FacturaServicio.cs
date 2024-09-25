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
    public class FacturaServicio : IFacturaAplicacion
    {
        private IFacturaRepository _repository;
        public FacturaServicio()
        {
            _repository = new FacturaRepositoryADO();
        }
        public bool Eliminar(int id)
        {
           return _repository.Delete(id);
        }

        public bool Modificar(Factura articulo)
        {
            return _repository.Update(articulo);
        }

        public bool Nuevo(Factura articulo)
        {
            return _repository.Create(articulo);
        }

        public Factura ObtenerPorId(int id)
        {
            return _repository.GetById(id);
        }

        public List<Factura> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        public List<Factura> ObtenerTodosConFiltros(string fechaInicio, string fechaFin, int idFormaPago)
        {
            return _repository.GetAllFiltro(fechaInicio, fechaFin, idFormaPago);
        }
    }
}
