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
    public class TipoCuentaService
    {
        private ITipoCuentaRepository _repository;
        public TipoCuentaService()
        {
            _repository = new TipoCuentaRepository();
        }

        public List<TipoCuenta> GetAll()
        {
            return _repository.GetAll();
        }
        public TipoCuenta Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
