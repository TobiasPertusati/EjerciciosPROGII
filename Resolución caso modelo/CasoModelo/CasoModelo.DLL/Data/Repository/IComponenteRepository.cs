using CasoModelo.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoModelo.DLL.Data.Repository
{
    public interface IComponenteRepository
    {
        List<Componente> GetAll();
    }
}
