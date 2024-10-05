using PrimerParcial_1W3_412301.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial_1W3_412301.DLL.Service
{
    public interface ICriptomonedaService
    {
        Task<List<Criptomoneda>> GetAllByCategoria(int categoria);
        Task<bool> Update(string sim, double valor, DateTime FechaActualizacion);
        Task<bool> LogicDelete(int id);
    }
}
