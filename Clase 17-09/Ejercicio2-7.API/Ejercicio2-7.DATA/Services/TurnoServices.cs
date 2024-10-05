using Ejercicio2_7.API.Entities;
using Ejercicio2_7.API.Services.Aplicaciones;
using Ejercicio2_7.DATA.Repository;
using Ejercicio2_7.DATA.Repository.Interfaces;

namespace Ejercicio2_7.API.Services
{
    public class TurnoServices : ITurnoAplicacion
    {
        private readonly ITurnoRepository _repository;
        public TurnoServices()
        {
            _repository = new TurnoRepositoryADO();
        }

        public Turno ContarTurnos(string fecha, string hora)
        {
            throw new NotImplementedException();
        }

        public bool InsertarTurno(Turno turno)
        {
            return _repository.InsertarTurno(turno);
        }
    }
}
