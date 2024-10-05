using EnviosWebApi.Models;

namespace EnviosWebApi.Repository
{
    public interface IEmpresaRepository
    {
        Task<List<TEmpresa>> GetAll();
        Task<TEmpresa> Get(int id);

        Task<bool> Update(TEmpresa empresa);
        Task<bool> Create(TEmpresa empresa);

        Task<bool> Delete(int id);
    }
}
