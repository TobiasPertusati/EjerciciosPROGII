using Ejercicio1_5.DATA.AccesoADatos;
using Ejercicio1_5.DATA.Interfaces;
using Ejercicio1_5.MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.DATA.Repository
{
    public class DetalleFacturaRepositoryADO : IDetalleFacturaRepository
    {
        public List<DetalleFactura> GetDetalles(int nroFac)
        {

            List<DetalleFactura> detalles = new List<DetalleFactura>();
            try
            {
                var datos = DataHelper.GetInstance();
                datos.SetearParametros("@NRO_FACTURA", nroFac);
                DataTable dt = datos.EjecutarSPQuery("SP_GET_DETALLES_FACTURA");
                foreach (DataRow dr in dt.Rows)
                {
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

