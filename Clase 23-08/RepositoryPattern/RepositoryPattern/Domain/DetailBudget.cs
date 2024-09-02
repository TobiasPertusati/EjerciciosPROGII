using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain
{
    public class DetailBudget
    {
        public Product? Product { get; set; }
        public int Count { get; set; }

        public double SubTotal()
        {
            return Count * Product.Precio; 
        }
    }
}   
