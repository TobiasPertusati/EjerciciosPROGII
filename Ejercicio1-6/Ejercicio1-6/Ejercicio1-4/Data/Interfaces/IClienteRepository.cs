using Ejercicio1_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Data.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> GetAll();
        Cliente Get(int id);

    }
}
