using Ejercicio2_7.API.Entities;
using Ejercicio2_7.DATA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DATA.Repository
{
    public class ServicioRepositoryADO : IServicioRepository
    {
        public List<Servicio> ConsultarServicios()
        {
            List<Servicio> servicios = new List<Servicio>();
            try
            {
                var helper = DataHelper.DataHelper.GetInstance();
                DataTable dt = helper.ExecuteSPQuery("SP_CONSULTAR_SERVICIOS");
                foreach (DataRow dr in dt.Rows)
                {
                    Servicio aux = new Servicio()
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Nombre = dr["nombre"].ToString(),
                        Costo = Convert.ToInt32(dr["costo"]),
                        enPromocion = dr["enPromocion"].ToString(),
                    };
                    servicios.Add(aux);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return servicios;
        }
    }
}
