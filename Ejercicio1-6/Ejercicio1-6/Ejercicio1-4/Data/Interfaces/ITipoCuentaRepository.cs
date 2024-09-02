using Ejercicio1_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Data.Interfaces
{
    public interface ITipoCuentaRepository
    {
        List<TipoCuenta> GetAll();
        TipoCuenta Get(int id);


    }
}
