using Ejercicio1_5.DATA.Interfaces;
using Ejercicio1_5.MODELOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.DATA.Repository
{
    public class ArticuloRepositoryADO : IArticuloRepository
    {
        public bool Guardar(Articulo articulo)
        {
            // UPSERT
            bool res = false;
            try
            {
                var dataHelper = AccesoADatos.DataHelper.GetInstance();
                dataHelper.SetearParametros("@ID_ARTICULO", articulo.IdArticulo);
                dataHelper.SetearParametros("@NOMBRE", articulo.Nombre);
                dataHelper.SetearParametros("@PRECIO_UNITARIO", articulo.PrecioUnitario);
                if (dataHelper.EjecutarSPDML("SP_UPSERT_ARTICULO") > 0)
                    res = true;
            }
            catch (SqlException)
            {
                res = false;
                throw;
            }
            catch (Exception)
            {
                res = false;
                throw;
            }
            return res;
        }

        public bool Eliminar(int id)
        {
            bool res = false;
            try
            {
                var dataHelper = AccesoADatos.DataHelper.GetInstance();
                dataHelper.SetearParametros("@ID_ARTICULO", id);
                if(dataHelper.EjecutarSPDML("SP_ELIMINAR_ARTICULO") > 0)
                    res = true;
            }
            catch (SqlException)
            {
                res = false;
                throw;
            }
            catch (Exception)
            {
                res = false;
                throw;
            }
            return res;
        }

        public Articulo ObtenerPorId(int id)
        {
            Articulo articulo = new Articulo();
            try
            {
                var dataHelper = AccesoADatos.DataHelper.GetInstance();
                dataHelper.SetearParametros("@ID_ARTICULO", id);
                DataTable dt = dataHelper.EjecutarSPQuery("SP_GET_ARTICULO");
                foreach (DataRow dr in dt.Rows)
                {
                    articulo.IdArticulo = Convert.ToInt32(dr["id_articulo"]);
                    articulo.Nombre = dr["nombre"].ToString();
                    articulo.PrecioUnitario = Convert.ToDouble(dr["precioUnitario"]);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return articulo;
        }

        public List<Articulo> ObtenerTodos()
        {
            List<Articulo> list = new List<Articulo>();
            try
            {
                var dataHelper = AccesoADatos.DataHelper.GetInstance();
                DataTable dt = dataHelper.EjecutarSPQuery("SP_GETALL_ARTICULOS");
                foreach (DataRow dr in dt.Rows)
                {
                    Articulo articulo = new Articulo()
                    {
                        IdArticulo = Convert.ToInt32(dr["id_articulo"]),
                        Nombre = dr["nombre"].ToString(),
                        PrecioUnitario = Convert.ToDouble(dr["precioUnitario"]),
                    };
                    list.Add(articulo);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
