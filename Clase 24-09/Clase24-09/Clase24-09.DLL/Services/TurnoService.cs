using Clase24_09.DLL.Data.Repository;
using Clase24_09.DLL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase24_09.DLL.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _repository;
        public TurnoService(ITurnoRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<Turno> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Save(Turno turno)
        {
            return _repository.Save(turno);
        }

        public bool Update(Turno turno)
        {
            return _repository.Update(turno);
        }
    }
}
