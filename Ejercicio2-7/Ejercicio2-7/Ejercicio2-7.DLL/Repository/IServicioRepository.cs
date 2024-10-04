using Ejercicio2_7.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DLL.Repository
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> GetAllASYNC();
    }
}
