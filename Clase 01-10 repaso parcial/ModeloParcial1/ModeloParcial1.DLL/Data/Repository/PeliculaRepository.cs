using Microsoft.EntityFrameworkCore;
using ModeloParcial1.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial1.DLL.Data.Repository
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly DBCineContext _context;

        public PeliculaRepository(DBCineContext context)
        {
            _context = context;
        }



        public async Task<bool> CreateASYNC(Pelicula pelicula)
        {
            await _context.Peliculas.AddAsync(pelicula);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> DeleteASYNC(int id, DateOnly fechaBaja, string motivoBaja)
        {
            Pelicula p = await GetByIdASYNC(id);
            if (p != null)
            {
                p.FechaBaja = fechaBaja;
                p.MotivoBaja = motivoBaja;
                _context.Peliculas.Update(p);
            }
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<Pelicula>> GetAllASYNC()
        {
            return await _context.Peliculas.Where(p => p.Estreno == true)
                .ToListAsync();
        }

        public async Task<List<Pelicula>> GetAllBetweenYears(int minYear, int maxYear)
        {
            return await _context.Peliculas
                .Where(p => p.Anio <= minYear && p.Anio <= maxYear)
                .ToListAsync();
        }

        public async Task<Pelicula> GetByIdASYNC(int id)
        {
            return await _context.Peliculas.FindAsync(id);
        }

        public async Task<bool> UpdateASYNC(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
