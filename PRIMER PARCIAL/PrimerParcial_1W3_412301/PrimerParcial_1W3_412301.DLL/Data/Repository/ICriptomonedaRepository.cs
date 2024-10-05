using PrimerParcial_1W3_412301.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial_1W3_412301.DLL.Data.Repository
{
    public interface ICriptomonedaRepository
    {
        Task<List<Criptomoneda>> GetAllByCategoria(int categoria);
        Task<bool> Update(string sim, double valor, DateTime fechaActualizacion);
        Task<bool> LogicDelete(int id);
        Task<Criptomoneda> GetById(int id);
    }
}
