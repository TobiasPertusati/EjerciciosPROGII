using Ejercicio2_7.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DLL.Services
{
    public interface ITurnoService
    {
        Task<List<Turno>> GetAllTurnosASYNC();

        Task<Turno> GetByIdAsync(int id);

        Task<bool> SaveAsync(Turno turno);

        Task<bool> DeleteByIdAsync(int id);
    }
}
