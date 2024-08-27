using RepositoryPattern.Data;
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

        
    }
}
