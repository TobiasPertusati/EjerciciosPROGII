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
        public async Task<bool> DeleteByIdAsync(int id, string motivoCancelacion)
        {
            return await _turnoRepository.DeleteByIdAsync(id, motivoCancelacion);
        }

        public async Task<List<Turno>> GetAllTurnosASYNC(string estado)
        {
            return await _turnoRepository.GetAllTurnosASYNC(estado);
        }

        public async Task<Turno> GetByIdAsync(int id)
        {
            return await _turnoRepository.GetByIdAsync(id);
        }
        public async Task<bool> CreateAsync(Turno turno)
        {
            return await _turnoRepository.CreateAsync(turno);
        }

        public async Task<bool> UpdateASYNC(Turno turno, string fecha, string hora)
        {
            return await _turnoRepository.UpdateASYNC(turno, fecha, hora);
        }

        public async Task<bool> ExistByFechaASYNC(string fecha, string hora, int id)
        {
            return await _turnoRepository.ExistByFechaASYNC(fecha, hora,id);
        }
    }
}
