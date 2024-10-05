using EnviosWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EnviosWebApi.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly EnviosContext _context;

        public EmpresaRepository(EnviosContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(TEmpresa empresa)
        {
            _context.TEmpresas.Add(empresa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            TEmpresa emp = await Get(id);
            _context.TEmpresas.Remove(emp);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TEmpresa> Get(int id)
        {
            return await _context.TEmpresas.FindAsync(id);
        }

        public async Task<List<TEmpresa>> GetAll()
        {
            return await _context.TEmpresas.ToListAsync();
        }

        public async Task<bool> Update(TEmpresa empresa)
        {
            _context.TEmpresas.Update(empresa);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}

