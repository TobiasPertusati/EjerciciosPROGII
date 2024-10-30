using ModeloParcialWebApi.Models;

namespace ModeloParcialWebApi.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetAll();
        bool Create(Pelicula oPelicula);
        bool Update(int id);

        List<Genero> GetAllGeneros();
        List<Pelicula> GetAllByYears(int anio1, int anio2);

        bool Delete(int id, string motivo);

    }
}
