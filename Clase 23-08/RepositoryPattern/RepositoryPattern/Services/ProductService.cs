using RepositoryPattern.Data;
using RepositoryPattern.Data.Interfaces;
using RepositoryPattern.Data.Repository;
using RepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services
{
    public class ProductService
    {
        private IProductRepository _repositiory;
        public ProductService()
        {
           _repositiory = new ProductRepositoryADO();
        }
        public List<Product> GetProducts()
        {
            return _repositiory.GetAll();
        }
        public Product GetProduct(int id)
        {
            return _repositiory.GetById(id);
        }
        public bool Upsert(Product product)
        {
            return _repositiory.Save(product);
        }
        public bool Delete(int id)
        {
            return _repositiory.Delete(id);
        }
        
    }
}
