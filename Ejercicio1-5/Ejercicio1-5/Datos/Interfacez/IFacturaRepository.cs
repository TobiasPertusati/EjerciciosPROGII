using Ejercicio1_5.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Datos.Interfacez
{
    public interface IFacturaRepository
    {
        List<Factura> GetAll();
        Factura Get(int nroFactura);
        bool Upsert(int nroFactura);
        bool Delete(int nroFactura);
    }
}
