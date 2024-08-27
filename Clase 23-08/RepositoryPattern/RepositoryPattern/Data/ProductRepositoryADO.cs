using RepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data
{
    public class ProductRepositoryADO : IProductRepository
    {
        DataHelper Dh = DataHelper.GetInstance();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            try
            {
                DataHelper.GetInstance().ExecuteSP("SP_LISTAR_PRODUCTOS");
                while (DataHelper.GetInstance().Reader.Read())
                {
                    Product product = new Product
                    {
                        Codigo = Convert.ToInt32(DataHelper.GetInstance().Reader["codigo"]),
                        Nombre = Convert.ToString(DataHelper.GetInstance().Reader["n_producto"]),
                        Precio = Convert.ToDouble(DataHelper.GetInstance().Reader["precio"]),
                        Stock = Convert.ToInt32(DataHelper.GetInstance().Reader["stock"]),
                        Activo = Convert.ToBoolean(DataHelper.GetInstance().Reader["[esta_activo]"])
                    };
                }
                DataHelper.GetInstance().CloseConnection();

            }
            catch (Exception)
            {
                throw;
            }
            return products;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
