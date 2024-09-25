using Ejercicio1_5.MODELOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.DATA.Interfaces
{
    public interface IFacturaRepository
    {

        List<Factura> GetAllFiltro(string fechaInicio, string fechaFin, int idFormaPago);

        List<Factura> GetAll();

        Factura GetById(int id);

        bool Create(Factura factura);
        bool Update(Factura factura);
        bool Delete(int nroFactura, SqlConnection? conn = null, SqlTransaction? t = null);

    }
}
