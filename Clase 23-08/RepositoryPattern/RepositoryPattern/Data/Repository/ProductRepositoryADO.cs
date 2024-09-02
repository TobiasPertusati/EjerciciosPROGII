using RepositoryPattern.Data.DataAccess;
using RepositoryPattern.Data.Interfaces;
using RepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Repository
{
    public class ProductRepositoryADO : IProductRepository
    {
        private DataHelper Dh = DataHelper.GetInstance();
        public bool Delete(int id)
        {
            Dh.SetParameters("@codigo", id);
            return Dh.ExecuteSPDML("SP_REGISTRAR_BAJA_PRODUCTO") > 0? true : false;
            
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            try
            {
                DataTable dt = Dh.ExecuteSPQuery("SP_RECUPERAR_PRODUCTOS");
                foreach (DataRow r in dt.Rows)
                {

                    Product product = new Product
                    {
                        Codigo = Convert.ToInt32(r["codigo"]),
                        Nombre = Convert.ToString(r["n_producto"]),
                        Precio = Convert.ToDouble(r["precio"]),
                        Stock = Convert.ToInt32(r["stock"]),
                        Activo = Convert.ToBoolean(r["esta_activo"])
                    };
                    products.Add(product);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return products;
        }

        public Product GetById(int id)
        {
            Product product = new();
            try
            {
                Dh.SetParameters("@codigo", id);
                DataTable dt = Dh.ExecuteSPQuery("SP_RECUPERAR_PRODUCTO_POR_CODIGO");
                foreach (DataRow r in dt.Rows)
                {
                    product.Codigo = Convert.ToInt32(r["codigo"]);
                    product.Nombre = Convert.ToString(r["n_producto"]);
                    product.Precio = Convert.ToDouble(r["precio"]);
                    product.Stock = Convert.ToInt32(r["stock"]);
                    product.Activo = Convert.ToBoolean(r["esta_activo"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        public bool Save(Product product)
        {
            Dh.SetParameters("@codigo", product.Codigo);
            Dh.SetParameters("@n_producto", product.Nombre);
            Dh.SetParameters("@precio", product.Precio);
            Dh.SetParameters("@stock", product.Stock);
            Dh.SetParameters("@esta_activo", product.Activo);
            return Dh.ExecuteSPDML("SP_GUARDAR_PRODUCTO") > 0 ? true : false;
        }
    }
}
