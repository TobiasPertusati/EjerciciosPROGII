using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;
        private SqlCommand _cmd;
        private SqlDataReader _reader;
        public SqlDataReader Reader
        {
            get { return _reader; }
            set { _reader = value; }
        }

        private DataHelper()
        {
            _connection = new SqlConnection(RepositoryPattern.Properties.Resources.StrConnection);
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
        // EJECUTAR SP
        public void ExecuteSP(string spName)
        {
            try
            {
                _connection.Open();
                _cmd.Connection = _connection;
                _cmd.CommandText = spName;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // CERRAR CONEXION
        public void CloseConnection()
        {
            _connection.Close();
        }

        // 
    }
}
