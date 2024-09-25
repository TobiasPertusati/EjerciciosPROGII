using Clase20_09_EF.DLL.Data.Models;
using Clase20_09_EF.DLL.Data.Repositories;
using Clase20_09_EF.DLL.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase20_09_EF.DLL.Data.Services
{
    public class LibroServicio
    {
        private readonly ILibroRepository _repository;
        public LibroServicio(LibroRepositoryEF repository)
        {
            _repository = repository;
        }

        public List<Libro> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
