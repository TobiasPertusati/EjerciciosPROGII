using Ejercicio1_4.Data.Interfaces;
using Ejercicio1_4.Data.Repository;
using Ejercicio1_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Services
{
    public class CuentaService
    {
        private ICuentaRepository _repository;
        public CuentaService()
        {
            _repository = new CuentaRepository();
        }

        public List<Cuenta> GetAll()
        {
            return _repository.GetAll();
        }

        public Cuenta Get(int id)
        {
            return _repository.Get(id);
        }
        public bool Upsert(Cuenta cuenta)
        {
            return _repository.Upsert(cuenta);
        }
        public bool Delete(int id) 
        { 
            return _repository.Delete(id);
        }
    }
}
