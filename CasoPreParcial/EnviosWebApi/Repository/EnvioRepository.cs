using EnviosWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EnviosWebApi.Repository
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly EnviosContext _context;
        public EnvioRepository(EnviosContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(TEnvio tEnvio)
        {
            _context.TEnvios.Add(tEnvio);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLogico(int id)
        {
            TEnvio e = await Get(id);
            if (e != null && (e.Estado != "Cancelado" || e.Estado == "Enviado"))
            {
                e.Estado = "Cancelado";
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TEnvio> Get(int id)
        {
            return await _context.TEnvios.FindAsync(id);
        }

        public async Task<List<TEnvio>> GetAll(DateTime fecha1, DateTime fecha2)
        {
            DateTime mayor;
            DateTime menor;
            if (fecha1 > fecha2)
            {
                mayor = fecha1;
                menor = fecha2;
            }
            else
            {
                menor = fecha1;
                mayor = fecha2;
            }

            return await _context.TEnvios
                .Where(env => env.FechaEnvio >= menor && env.FechaEnvio <= mayor && env.Estado != "cancelado")
                .ToListAsync();
        }

        public async Task<bool> Update(TEnvio tEnvio)
        {
            _context.TEnvios.Update(tEnvio);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
