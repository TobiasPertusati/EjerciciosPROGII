using Ejercicio2_7.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DLL.Services
{
    public interface IServicioService
    {
        Task<List<Servicio>> GetAllASYNC(string promo);
        Task<Servicio> GetByIdASYNC(int id);
        Task<bool> SaveASYNC(Servicio servicio);
        Task<bool> LogicDelete(int id);
    }
}
