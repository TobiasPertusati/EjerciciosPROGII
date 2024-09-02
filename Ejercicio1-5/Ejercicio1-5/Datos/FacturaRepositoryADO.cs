using Ejercicio1_5.Datos.Interfacez;
using Ejercicio1_5.Datos.AccesoADatos;
using Ejercicio1_5.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Ejercicio1_5.Datos
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        public bool Delete(int nroFactura)
        {
            throw new NotImplementedException();
        }

        public Factura Get(int nroFactura)
        {
            throw new NotImplementedException();
        }

        public List<Factura> GetAll()
        {
            List<Factura> list = new List<Factura>();
            try
            {
                var datos = AccesoADatos.AccesoADatos.GetInstance();
                DataTable dt = datos.EjecutarSPQuery("SP_GETALL_FACTURAS");
                foreach (DataRow r in dt.Rows)
                {
                    Factura aux = new Factura();
                    aux.NroFacura = Convert.ToInt32(r["nro_factura"]);
                    aux.Fecha = Convert.ToDateTime(r["fecha"]);
                    aux.FormaPago = new FormaPago
                    {
                        IdFormaPago = Convert.ToInt32(r["id_forma_Pago"]),
                        Nombre = r["nombre"].ToString()
                    };
                    aux.Cliente = r["cliente"].ToString();
                    list.Add(aux);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;

        }

        public bool Upsert(int nroFactura)
        {
            throw new NotImplementedException();
        }
    }
}
