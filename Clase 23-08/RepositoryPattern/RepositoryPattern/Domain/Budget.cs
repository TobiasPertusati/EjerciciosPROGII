using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain
{
    public class Budget
    {
        public int Id { get; set; }
        public string? Client { get; set; }
        public DateTime Date { get; set; }
        public int Expiration { get; set; }
        public List<DetailBudget> Details { get; set; }

        public Budget()
        {
            Details = new List<DetailBudget>();
        }

        public double Total()
        {
            double total = 0;
            foreach (var d in Details)
            {
                total += d.SubTotal();
            }
            return total;
        }
        public void AddDetail(DetailBudget detail)
        {
            this.Details.Add(detail);
        }
        public void RemoveDetail(DetailBudget detail)
        {
            this.Details.Remove(detail);
        }
    }
}
