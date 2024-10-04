using CasoModelo.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoModelo.DLL.Data.Repository
{
    public class ComponenteRepository : IComponenteRepository
    {
        private readonly DBCasoModeloContext _context;
        public ComponenteRepository(DBCasoModeloContext context)
        {
            _context = context;
        }

        public List<Componente> GetAll()
        {
           return _context.Componentes.ToList();
        }
    }
}
