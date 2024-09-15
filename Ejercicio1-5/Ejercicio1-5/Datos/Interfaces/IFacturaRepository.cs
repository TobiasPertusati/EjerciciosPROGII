using Ejercicio1_5.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Datos.Interfacez
{
    public interface IFacturaRepository
    {
        List<Factura> GetAll();
        Factura GetById(int nroFactura);
        bool Create(Factura factura);
        bool Update(Factura factura);
        bool Delete(int nroFactura,SqlConnection? conn = null, SqlTransaction? t = null);
    }
}
