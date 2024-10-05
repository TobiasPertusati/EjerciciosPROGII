using Ejercicio2_7.API.Entities;
using Ejercicio2_7.API.Services.Aplicaciones;
using Ejercicio2_7.DATA.Repository;
using Ejercicio2_7.DATA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DATA.Services
{
    public class ServicioService : IServicioAplicacion
    {
        private readonly IServicioRepository _repository;
        public ServicioService()
        {
            _repository = new ServicioRepositoryADO();
        }

        public List<Servicio> ConsultarServicios()
        {
            return _repository.ConsultarServicios();
        }
    }
}
