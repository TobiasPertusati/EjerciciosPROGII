using Ejercicio2_7.DLL.Data.Models;
using Ejercicio2_7.DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DLL.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;
        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _turnoRepository.DeleteByIdAsync(id);
        }

        public async Task<List<Turno>> GetAllTurnosASYNC()
        {
            return await _turnoRepository.GetAllTurnosASYNC();
        }

        public async Task<Turno> GetByIdAsync(int id)
        {
            return await _turnoRepository.GetByIdAsync(id);
        }
        public async Task<bool> SaveAsync(Turno turno)
        {
            return await _turnoRepository.SaveAsync(turno);
        }
    }
}
