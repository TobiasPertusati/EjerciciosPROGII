using ModeloParcial1.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial1.DLL.Services
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> GetAllASYNC();
        Task<List<Pelicula>> GetAllBetweenYears(int minYear, int maxYear);
        Task<Pelicula> GetByIdASYNC(int id);
        Task<bool> CreateASYNC(Pelicula pelicula);
        Task<bool> UpdateASYNC(Pelicula pelicula);
        Task<bool> DeleteASYNC(int id, DateOnly fechaBaja, string motivoBaja);
    }
}
