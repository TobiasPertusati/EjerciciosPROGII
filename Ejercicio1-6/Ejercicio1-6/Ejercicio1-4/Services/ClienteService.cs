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
    public class ClienteService
    {
        private IClienteRepository _repository;
        public ClienteService()
        {
            _repository = new ClienteRepository();
        }
        public bool New(Cliente cliente)
        {
            return _repository.NuevoCliente(cliente);
        }
        public List<Cliente> GetAll()
        {
            return _repository.GetAll();
        }
        public Cliente Get(int id)
        {
            return _repository.Get(id);
        }

        public bool Modificar(Cliente cliente)
        {
            return _repository.ModificarCliente(cliente);
        }
    }
}
