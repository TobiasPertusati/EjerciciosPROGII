using Clase24_09.DLL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase24_09.DLL.Services
{
    public interface ITurnoService
    {
        List<Turno> GetAll();
        bool Save(Turno turno);
        bool Update(Turno turno);
        bool Delete(int id);

    }
}
