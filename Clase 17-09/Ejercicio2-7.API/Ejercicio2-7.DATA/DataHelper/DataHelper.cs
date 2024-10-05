using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_7.DATA.DataHelper
{
    public class DataHelper
    {
        private DataHelper()
        {
            _connection = new SqlConnection("server=.\\SQLEXPRESS; database=DB_TURNOS; integrated security=true;");
            _cmd = new SqlCommand();
        }
        private SqlConnection _connection;
        private SqlCommand _cmd;
        private static DataHelper? _instance;

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }


        public void SetearParametros(string name, object obj)
        {
            _cmd.Parameters.AddWithValue(name, obj);
        }
        public bool ExecuteSPDML(string spName)
        {
            bool res = false;
            try
            {
                _connection.Open();
                _cmd.CommandText = spName;
                _cmd.Connection = _connection;
                _cmd.CommandType = CommandType.StoredProcedure;
                if (_cmd.ExecuteNonQuery() > 0)
                    res = true;
                _cmd.Parameters.Clear();
            }
            catch (SqlException)
            {
                res = false;
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return res;
        }

        public DataTable ExecuteSPQuery(string spName)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                _cmd.CommandText = spName;
                _cmd.Connection = _connection;
                _cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(_cmd.ExecuteReader());
                _cmd.Parameters.Clear();
            }
            catch (SqlException)
            {
                dt = null;
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public void CloseConnection()
        {
            if (_connection.State is ConnectionState.Open && _connection != null)
            {
                _connection.Close();
            }
        }




    }
}
