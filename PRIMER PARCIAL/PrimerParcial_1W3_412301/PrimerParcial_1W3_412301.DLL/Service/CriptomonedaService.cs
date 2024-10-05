using PrimerParcial_1W3_412301.DLL.Data.Models;
using PrimerParcial_1W3_412301.DLL.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial_1W3_412301.DLL.Service
{
    public class CriptomonedaService : ICriptomonedaService
    {
        private readonly ICriptomonedaRepository _repository;
        public CriptomonedaService(ICriptomonedaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Criptomoneda>> GetAllByCategoria(int categoria)
        {
            return await _repository.GetAllByCategoria(categoria);
        }

        public async Task<bool> LogicDelete(int id)
        {
            return await _repository.LogicDelete(id);
        }

        public async Task<bool> Update(string sim, double valor, DateTime fechaActualizacion)
        {
            return await _repository.Update(sim, valor, fechaActualizacion);
        }
    }
}
