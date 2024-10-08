using Ejercicio2_7.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DLL.Repository
{
    public interface ITurnoRepository
    {
        Task<List<Turno>> GetAllTurnosASYNC(string estado);
        Task<bool> ExistByFechaASYNC(string fecha, string hora, int id);
        Task<Turno> GetByIdAsync(int id);
        Task<bool> UpdateASYNC(Turno turno, string fecha, string hora);
        Task<bool> CreateAsync(Turno turno);

        Task<bool> DeleteByIdAsync(int id, string motivoCancelacion);

    }
}
