using RepositoryPattern.Data.DataAccess;
using RepositoryPattern.Data.Interfaces;
using RepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Repository
{
    public class BudgetRepositoryADO : IBudgetRepository
    {
        private DataHelper data = DataHelper.GetInstance();
        public List<Budget> GetAll()
        {
            throw new NotImplementedException();
        }

        public Budget GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Upsert(Budget budget)
        {
            bool res = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;
            try
            {
                cnn = data.GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();
                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", budget.Client);
                cmd.Parameters.AddWithValue("@vigencia", budget.Expiration);

                SqlParameter param = new("id", System.Data.SqlDbType.Int);
                param.Direction = System.Data.ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                int budgetId = Convert.ToInt32(param.Value);
                var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                cmdDetail.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (DetailBudget d in budget.Details)
                {
                    int detailId = 1;
                    cmdDetail.Parameters.Clear();
                    cmdDetail.Parameters.AddWithValue("@presupuesto", budgetId);
                    cmdDetail.Parameters.AddWithValue("@id_detalle", detailId);
                    cmdDetail.Parameters.AddWithValue("@producto", d.Product.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", d.Count);
                    cmdDetail.Parameters.AddWithValue("@precio", d.Product.Precio);
                    cmdDetail.ExecuteNonQuery();
                    detailId++;
                }

                cmd.Parameters.Clear();

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                    t.Rollback();
                res = false;
            }
            finally
            {
                if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return res;
        }
    }
}
