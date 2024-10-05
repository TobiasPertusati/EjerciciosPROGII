using EnviosWebApi.Models;

namespace EnviosWebApi.Repository
{
    public interface IEnvioRepository
    {
        Task<List<TEnvio>> GetAll(DateTime fecha1, DateTime fecha2);
        Task<TEnvio> Get(int id);

        Task<bool> Update(TEnvio tEnvio);
        Task<bool> Create(TEnvio tEnvio);

        Task<bool> DeleteLogico(int id);
    }
}
