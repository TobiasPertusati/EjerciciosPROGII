using Ejercicio2_7.DLL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DLL.Repository
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly DB_TURNOSContext _context;

        public TurnoRepository(DB_TURNOSContext context)
        {
            _context = context;
        }

        public async Task<List<Turno>> GetAllTurnosASYNC()
        {
            return await _context.TTurnos.ToListAsync();
        }

        public async Task<Turno> GetByIdAsync(int id)
        {
            return await _context.TTurnos.FindAsync(id);
        }

        public async Task<bool> SaveAsync(Turno turno)
        {
            if (turno.Id == 0)
            {
                await _context.TTurnos.AddAsync(turno);
            }
            else
            {
                _context.TTurnos.Update(turno);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            Turno t = await GetByIdAsync(id);
            if (t != null)
            {
                _context.TTurnos.Remove(t);
            }

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
