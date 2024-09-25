using Ejercicio1_5.MODELOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.DATA.Interfaces
{
    public interface IDetalleFacturaRepository
    {
        List<DetalleFactura> GetDetalles(int nroFac);
    }
}
