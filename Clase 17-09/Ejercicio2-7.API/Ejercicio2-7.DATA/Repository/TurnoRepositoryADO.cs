using Ejercicio2_7.API.Entities;
using Ejercicio2_7.DATA.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DATA.Repository
{
    public class TurnoRepositoryADO : ITurnoRepository
    {
        public Turno ContarTurno(string fecha, string hora)
        {
            throw new NotImplementedException();
        }

        public bool InsertarTurno(Turno turno)
        {
            bool res = true;
            SqlTransaction t = null;
            SqlConnection conn = DataHelper.DataHelper.GetInstance().GetConnection();
            try
            {
                conn.Open();
                t = conn.BeginTransaction();

                SqlCommand cmd = new("SP_INSERTAR_TURNO", conn, t);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HORA", turno.Hora);
                cmd.Parameters.AddWithValue("@FECHA", turno.Fecha);
                cmd.Parameters.AddWithValue("@CLIENTE", turno.Cliente);


                SqlParameter par = new("@ID_TURNO", System.Data.SqlDbType.Int);
                par.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(par);

                cmd.ExecuteNonQuery();
                int idTurno = (int)par.Value;

                cmd.Parameters.Clear();

                cmd.CommandText = "SP_INSERTAR_DETALLES";
                cmd.Parameters.AddWithValue("@id_turno", idTurno);
                cmd.Parameters.AddWithValue("@observaciones", turno.Detalle.Observaciones);
                cmd.Parameters.AddWithValue("@id_servicio", turno.Detalle.Servicio.Id);

                cmd.ExecuteNonQuery();

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    res = false;
                    t.Rollback();
                }
                throw;
            }
            finally
            {
                if (conn.State is System.Data.ConnectionState.Open && conn != null)
                {
                    conn.Close();
                }
            }
            return res;
        }
    }
}
