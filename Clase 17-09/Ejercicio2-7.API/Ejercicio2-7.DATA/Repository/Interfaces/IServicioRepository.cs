using Ejercicio2_7.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DATA.Repository.Interfaces
{
    public interface IServicioRepository
    {
        List<Servicio> ConsultarServicios();

    }
}
