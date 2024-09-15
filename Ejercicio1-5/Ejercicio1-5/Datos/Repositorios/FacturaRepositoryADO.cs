using Ejercicio1_5.Datos.Interfacez;
using Ejercicio1_5.Datos.AccesoADatos;
using Ejercicio1_5.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ejercicio1_5.Datos.Repositorios
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        private SqlConnection _conn;

        public bool Create(Factura factura)
        {
            bool res = true;

            SqlConnection conn = AccesoADatos.AccesoADatos.GetInstance().GetConnection();
            SqlTransaction t = null;

            try
            {
                conn.Open();
                t = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand("SP_NUEVA_FACTURA", conn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FORMA_PAGO", factura.FormaPago.IdFormaPago);
                cmd.Parameters.AddWithValue("@FECHA", factura.Fecha);
                cmd.Parameters.AddWithValue("@CLIENTE", factura.Cliente);

                SqlParameter param = new SqlParameter("@NRO_FACTURA", DbType.Int32);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int nro_factura = (int)param.Value;

                int idDetalle = 0;
                SqlCommand cmdDetails = new("SP_NUEVO_DETALLE", conn, t);
                cmdDetails.CommandType = CommandType.StoredProcedure;

                if (factura.Detalles.Count == 0)
                    throw new Exception();
                foreach (DetalleFactura d in factura.Detalles)
                {
                    idDetalle++;
                    cmdDetails.Parameters.Clear();
                    cmdDetails.Parameters.AddWithValue("@ID_DETALLE", idDetalle);
                    cmdDetails.Parameters.AddWithValue("@ID_ARTICULO", d.Articulo.IdArticulo);
                    cmdDetails.Parameters.AddWithValue("@CANTIDAD", d.Cantidad);
                    cmdDetails.Parameters.AddWithValue("@FACTURA", nro_factura);
                    cmdDetails.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (SqlException)
            {
                res = false;
                if (t != null)
                    t.Rollback();
            }
            catch (Exception)
            {
                res = false;
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }

        public bool Update(Factura factura)
        {
            bool res = true;
            SqlTransaction t = null;
            SqlConnection conn = AccesoADatos.AccesoADatos.GetInstance().GetConnection();
            try
            {
                conn.Open();
                t = conn.BeginTransaction();
                // PRIMERO ELIMINO LA FACTURA
                Delete(factura.NroFacura, conn, t);

                // DESPUES LE PASO LA FACTURA MODIFICADA 
                SqlCommand cmd = new SqlCommand("SP_FACTURA_MODIFICADA", conn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FORMA_PAGO", factura.FormaPago.IdFormaPago);
                cmd.Parameters.AddWithValue("@FECHA", factura.Fecha);
                cmd.Parameters.AddWithValue("@CLIENTE", factura.Cliente);
                cmd.Parameters.AddWithValue("@NRO_FACTURA", factura.NroFacura);

                cmd.ExecuteNonQuery();

                if (factura.Detalles.Count == 0)
                    throw new Exception();

                SqlCommand cmdDetails = new("SP_NUEVO_DETALLE", conn, t);
                cmdDetails.CommandType = CommandType.StoredProcedure;
                int idDetalle = 0;

                foreach (DetalleFactura d in factura.Detalles)
                {
                    idDetalle++;
                    cmdDetails.Parameters.Clear();
                    cmdDetails.Parameters.AddWithValue("@ID_DETALLE", idDetalle);
                    cmdDetails.Parameters.AddWithValue("@ID_ARTICULO", d.Articulo.IdArticulo);
                    cmdDetails.Parameters.AddWithValue("@CANTIDAD", d.Cantidad);
                    cmdDetails.Parameters.AddWithValue("@FACTURA", factura.NroFacura);
                    cmdDetails.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (SqlException)
            {
                res = false;
                if (t != null)
                    t.Rollback();
            }
            catch (Exception)
            {
                res = false;
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return res;
        }

        public bool Delete(int nroFactura, SqlConnection? conn = null, SqlTransaction? t = null)
        {
            bool res = true;
            bool flag = false;
            if (conn != null && t != null)
            {
                flag = true;
            }
            else
            {
                conn = AccesoADatos.AccesoADatos.GetInstance().GetConnection();
                t = null;
            }
            try
            {
                if (!flag)
                {
                    conn.Open();
                    t = conn.BeginTransaction();
                }
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_DETALLES_FACTURA", conn, t);  // ELMINO TODOS LOS DETALLES DE ESA FACTURA
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NRO_FACTURA", nroFactura);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SP_ELIMINAR_FACTURA"; // DESPUES LA FACTURA
                cmd.ExecuteNonQuery();
                if (!flag)
                    t.Commit();
            }
            catch (SqlException)
            {
                res = false;
                if (t != null)
                    t.Rollback();
            }
            catch (Exception)
            {
                res = false;
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open && !flag)
                {
                    conn.Close();
                }
            }
            return res;
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

                    DetalleFacturaRepositoryADO detallerepo = new DetalleFacturaRepositoryADO();
                    aux.Detalles = detallerepo.GetDetalles(aux.NroFacura);

                    list.Add(aux);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public Factura GetById(int nroFactura)
        {
            Factura factura = new();
            try
            {
                var datos = AccesoADatos.AccesoADatos.GetInstance();
                datos.SetearParametros(nroFactura, "@NRO_FACTURA");
                DataTable dt = datos.EjecutarSPQuery("SP_GET_FACTURA");
                foreach (DataRow r in dt.Rows)
                {
                    factura.NroFacura = Convert.ToInt32(r["nro_factura"]);
                    factura.Fecha = Convert.ToDateTime(r["fecha"]);
                    factura.FormaPago = new FormaPago
                    {
                        IdFormaPago = Convert.ToInt32(r["id_forma_Pago"]),
                        Nombre = r["nombre"].ToString()
                    };
                    factura.Cliente = r["cliente"].ToString();

                    DetalleFacturaRepositoryADO detallerepo = new DetalleFacturaRepositoryADO();
                    factura.Detalles = detallerepo.GetDetalles(factura.NroFacura);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return factura;
        }
    }
}

