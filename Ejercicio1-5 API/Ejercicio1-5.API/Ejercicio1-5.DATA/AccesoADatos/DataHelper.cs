using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.DATA.AccesoADatos
{

    public class DataHelper
    {
        private static DataHelper? _instance;
        private SqlConnection _conexion { get; set; }
        private SqlCommand _cmd;

        private DataHelper()
        {
            _conexion = new SqlConnection("server=.\\SQLEXPRESS; database=EJ_1_5_PROGII; integrated security=true");
            _cmd = new SqlCommand();
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        // METODOS PARA TRABAJAR CON ADO

        public SqlConnection GetConnection()
        {
            return _conexion;
        }

        // SETEAR PARAMETROS
        public void SetearParametros(string name, object obj)
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
            if (_conexion != null && _conexion.State == System.Data.ConnectionState.Open)
            {
                _conexion.Close();
            }
        }

    }
}
