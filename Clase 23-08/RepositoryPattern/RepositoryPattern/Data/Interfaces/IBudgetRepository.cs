using RepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Interfaces
{
    public interface IBudgetRepository
    {
        List<Budget> GetAll();
        Budget GetById(int id);
        bool Upsert(Budget budget);

    }
}
