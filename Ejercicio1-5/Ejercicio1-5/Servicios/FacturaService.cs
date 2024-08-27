using Ejercicio1_5.Datos;
using Ejercicio1_5.Datos.Interfacez;
using Ejercicio1_5.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Servicios
{
    public class FacturaService
    {
        private IFacturaRepository _repository;

        public FacturaService()
        {
            _repository = new FacturaRepositoryADO();
        }

        public List<Factura> GetAll() 
        { 
            return _repository.GetAll();
        }
    }
}
