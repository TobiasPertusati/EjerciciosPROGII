using Ejercicio2_7.DLL.Data.Models;
using Ejercicio2_7.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DLL.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;
        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<Servicio>> GetAllASYNC(string promo)
        {
            return await _repository.GetAllASYNC(promo);
        }

        public async Task<Servicio> GetByIdASYNC(int id)
        {
            return await _repository.GetASYNC(id);
        }
        public async Task<bool> SaveASYNC(Servicio servicio)
        {
            return await _repository.SaveASYNC(servicio);
        }

        public async Task<bool> LogicDelete(int id)
        {
            return await _repository.LogicDeleteASYNC(id);
        }

    }
}
