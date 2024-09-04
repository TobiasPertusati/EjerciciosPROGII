using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Data.DataAccess
{
    public class DataHelper
    {
        private SqlConnection _connection;
        private SqlCommand _cmd;
        private static DataHelper? _instance;

        private DataHelper()
        {
            _connection = new SqlConnection("server=.\\SQLEXPRESS; database=EJ_1_6_PROGII; integrated security=true");
            _cmd = new SqlCommand();
        }
        public SqlConnection GetConnection()
        {
            return _connection;
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public void SetearParametros(object obj, string name)
        {
            _cmd.Parameters.AddWithValue(name, obj);
        }
        public DataTable EjecutarSPQuery(string SPNAME)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                _cmd.Connection = _connection;
                _cmd.CommandText = SPNAME;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dt.Load(_cmd.ExecuteReader());
                _cmd.Parameters.Clear();

            }
            catch (SqlException)
            {
                dt = null;
            }
            finally
            {
                _connection.Close();
            }
            return dt;
        }
        public bool EjecutarSPDML(string SPNAME)
        {
            bool res;
            try
            {
                _connection.Open();
                _cmd.Connection = _connection;
                _cmd.CommandText = SPNAME;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.ExecuteNonQuery();
                _cmd.Parameters.Clear();
                res = true;
            }
            catch (SqlException)
            {
                res = false;
            }
            finally
            {
                _connection.Close();
            }
            return res;
        }

    }
}
