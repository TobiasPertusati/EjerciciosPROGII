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

        public async Task<List<Turno>> GetAllTurnosASYNC(string estado)
        {
            List<Turno> turnos;
            switch (estado)
            {
                case "Cancelados":
                    turnos = await _context.TTurnos
                        .Include(t => t.TDetallesTurnos)
                        .Where(x => x.FechaCancelacion != null)
                        .ToListAsync();
                    break;
                case "Pendientes":
                    turnos = await _context.TTurnos
                        .Include(t => t.TDetallesTurnos)
                        .Where(x => x.FechaCancelacion == null)
                        .ToListAsync();
                    break;
                default:
                    turnos = await _context.TTurnos
                        .Include(t => t.TDetallesTurnos)
                        .ToListAsync();
                    break;
            }
            return turnos;
        }
        public async Task<bool> ExistByFechaASYNC(string fecha, string hora, int id)
        {
            Turno t = await _context.TTurnos.FirstOrDefaultAsync(t => t.Fecha == fecha && t.Hora == hora && t.Id != id);
            return t == null ? false : true;
        }

        public async Task<Turno> GetByIdAsync(int id)
        {
            return await _context.TTurnos.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Turno turno)
        {
            await _context.TTurnos.AddAsync(turno);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateASYNC(Turno turno, string fecha, string hora)
        {
            // Actualizar los datos de una turno siempre que la fecha/hora sean anteriores a los confirmados en su creación 

            if (turno.FechaCancelacion == null)
            {
                DateTime fechaTurno = Convert.ToDateTime(turno.Fecha + " " + turno.Hora);

                DateTime fechaActual = Convert.ToDateTime(fecha);
                if (fechaActual < fechaTurno)
                {
                    _context.TTurnos.Update(turno);
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id, string motivoCancelacion)
        {
            Turno t = await GetByIdAsync(id);
            DateTime fechaCancelacion = DateTime.Now;
            DateTime fechaTurno = Convert.ToDateTime(t.Fecha + " " + t.Hora);

            if (t != null && t.FechaCancelacion == null && fechaTurno > fechaCancelacion)
            {
                t.FechaCancelacion = DateOnly.Parse(fechaCancelacion.ToShortDateString());
                t.MotivoCancelacion = motivoCancelacion;
            }

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
