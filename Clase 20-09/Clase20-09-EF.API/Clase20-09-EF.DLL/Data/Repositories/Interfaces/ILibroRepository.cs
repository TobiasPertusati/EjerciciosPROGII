using Clase20_09_EF.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase20_09_EF.DLL.Data.Repositories.Interfaces
{
    public interface ILibroRepository
    {
        List<Libro> GetAll();
        Libro? GetById(int id);
        bool Create(Libro libro);
        bool Update(Libro libro);
        bool Delete(int id);
    }
}
