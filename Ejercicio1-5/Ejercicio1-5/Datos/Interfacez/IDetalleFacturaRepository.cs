using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Datos.Interfacez
{
    public interface IDetalleFacturaRepository
    {
        void Get(int nroFac, int nroCli);
    }
}
