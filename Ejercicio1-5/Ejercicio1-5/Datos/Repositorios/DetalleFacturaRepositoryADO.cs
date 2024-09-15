using Ejercicio1_5.Datos.Interfacez;
using Ejercicio1_5.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Datos.Repositorios
{
    public class DetalleFacturaRepositoryADO : IDetalleFacturaRepository
    {
        public List<DetalleFactura> GetDetalles(int nroFac)
        {
            List<DetalleFactura> detalles = new List<DetalleFactura>();
            try
            {
                var datos = AccesoADatos.AccesoADatos.GetInstance();
                datos.SetearParametros(nroFac, "@NRO_FACTURA");
                DataTable dt = datos.EjecutarSPQuery("SP_GET_DETALLES_FACTURA");
                foreach (DataRow dr in dt.Rows)
                {
                 //   A.id_articulo,
	                //A.nombre,
	                //A.precioUnitario,
	                //DF.cantidad
                    DetalleFactura aux = new();
                    Articulo a = new Articulo();
                    a.IdArticulo = Convert.ToInt32(dr["id_articulo"]);
                    a.Nombre = dr["nombre"].ToString();
                    a.PrecioUnitario = Convert.ToDouble(dr["precioUnitario"]);
                    aux.Cantidad = Convert.ToInt32(dr["cantidad"]);
                    aux.Articulo = a;

                    detalles.Add(aux);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return detalles;
        }

    }
}
