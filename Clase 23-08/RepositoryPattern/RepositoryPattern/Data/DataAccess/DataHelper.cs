using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.DataAccess
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;
        private SqlCommand _cmd;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.StrConnection);
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
        public void SetParameters(string name, object obj)
        {
            _cmd.Parameters.AddWithValue(name, obj);
        }


        // EJECUTAR SP QUERY
        public DataTable ExecuteSPQuery(string spName)
        {
            DataTable dt = new();
            try
            {
                _connection.Open();
                _cmd.Connection = _connection;
                _cmd.CommandText = spName;
                _cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(_cmd.ExecuteReader());
                _cmd.Parameters.Clear();
                CloseConnection();
            }
            catch (SqlException)
            {
                dt = null;
            }
            return dt;
        }

        public int ExecuteSPDML(string spName)
        {
            int rows;
            try
            {
                _connection.Open();
                _cmd.Connection = _connection;
                _cmd.CommandText = spName;
                _cmd.CommandType = CommandType.StoredProcedure;
                rows = _cmd.ExecuteNonQuery();
                _cmd.Parameters.Clear();
                CloseConnection();
            }
            catch (SqlException)
            {
                rows = 0;
            }
            return rows;
        }

        // CERRAR CONEXION
        public void CloseConnection()
        {
            _connection.Close();
        }
        public SqlConnection GetConnection()
        {
            return _connection;   
        }

        public int ExecuteTransaction(List<string> procedures,SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        // 
    }
}
