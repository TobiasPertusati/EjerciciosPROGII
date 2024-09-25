using Clase20_09_EF.DLL.Data.Models;
using Clase20_09_EF.DLL.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase20_09_EF.DLL.Data.Repositories
{
    public class LibroRepositoryEF : ILibroRepository
    {
        private readonly clase_20_09DbContext _context;

        public LibroRepositoryEF(clase_20_09DbContext context)
        {
            _context = context;
        }

        public bool Create(Libro libro)
        {
            _context.Libros.Add(libro);
            return _context.SaveChanges() > 1 ? true : false;
        }

        public bool Delete(int id)
        {
            var libroRemove = GetById(id);
            if (libroRemove != null)
            {
                _context.Libros.Remove(libroRemove);
            }
            return _context.SaveChanges() > 1 ? true : false;
        }

        public List<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public Libro? GetById(int id)
        {
            return _context.Libros.Find(id);
        }

        public bool Update(Libro libro)
        {
            if (libro != null)
            {
                _context.Libros.Update(libro);
            }
            return _context.SaveChanges() > 1 ? true : false;
        }
    }
}
