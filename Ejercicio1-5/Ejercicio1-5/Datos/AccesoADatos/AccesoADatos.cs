using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Datos.AccesoADatos
{
    public class AccesoADatos
    {
        private static AccesoADatos? _instance;
        private SqlConnection _conexion { get; set; }
        private SqlCommand _cmd;

        private AccesoADatos()
        {
            _conexion = new SqlConnection("server=.\\SQLEXPRESS; database=EJ_1_5_PROGII; integrated security=true");
            _cmd = new SqlCommand();
        }
        public static AccesoADatos GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AccesoADatos();
            }
            return _instance;
        }

        // METODOS PARA TRABAJAR CON ADO

        // SETEAR PARAMETROS
        public void SetearParametros(object obj, string name)
        {
            _cmd.Parameters.AddWithValue(name, obj);
        }

        // EJECUTAR SP
        public DataTable EjecutarSPQuery(string SP)
        {
            DataTable dt = new();
            try
            {
                _conexion.Open();
                _cmd.Connection = _conexion;
                _cmd.CommandText = SP;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dt.Load(_cmd.ExecuteReader());
                LimpiarParametros();
                CerrarConexion();
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
        public int EjecutarSPDML(string SP)
        {
            int rows;
            try
            {
                _conexion.Open();
                _cmd.Connection = _conexion;
                _cmd.CommandText = SP;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                rows = _cmd.ExecuteNonQuery();
                LimpiarParametros();
                CerrarConexion();
            }
            catch (SqlException)
            {
                rows = 0;
            }

            return rows;
        }
        public void LimpiarParametros()
        {
            _cmd.Parameters.Clear();
        }

        // CERRAR CONEXIÓN 
        public void CerrarConexion()
        {
            _conexion.Close();
        }
        // 



    }
}
