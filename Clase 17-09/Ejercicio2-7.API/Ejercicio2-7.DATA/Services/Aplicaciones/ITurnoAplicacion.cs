using Ejercicio2_7.API.Entities;

namespace Ejercicio2_7.API.Services.Aplicaciones
{
    public interface ITurnoAplicacion
    {
        Turno ContarTurnos(string fecha, string hora);
        bool InsertarTurno(Turno turno);

    }
}
