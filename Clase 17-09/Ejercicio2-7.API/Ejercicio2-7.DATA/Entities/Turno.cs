namespace Ejercicio2_7.API.Entities
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string? Fecha { get; set; }
        public string? Hora { get; set; }
        public string? Cliente { get; set; }

        public DetalleTurno? Detalle { get; set; }



    }
}
