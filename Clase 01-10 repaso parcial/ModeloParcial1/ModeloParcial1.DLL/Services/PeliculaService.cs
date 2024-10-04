using ModeloParcial1.DLL.Data.Models;
using ModeloParcial1.DLL.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial1.DLL.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _repository;
        public PeliculaService(IPeliculaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateASYNC(Pelicula pelicula)
        {
            return await _repository.CreateASYNC(pelicula);
        }

        public async Task<bool> DeleteASYNC(int id, DateOnly fechaBaja, string motivoBaja)
        {
            return await _repository.DeleteASYNC(id, fechaBaja, motivoBaja);
        }

        public async Task<List<Pelicula>> GetAllASYNC()
        {
            return await _repository.GetAllASYNC();
        }

        public async Task<List<Pelicula>> GetAllBetweenYears(int minYear, int maxYear)
        {
            return await _repository.GetAllBetweenYears(minYear, maxYear);
        }

        public async Task<Pelicula> GetByIdASYNC(int id)
        {
            return await _repository.GetByIdASYNC(id);
        }
        public async Task<bool> UpdateASYNC(Pelicula pelicula)
        {
            return await _repository.UpdateASYNC(pelicula);
        }
    }
}
