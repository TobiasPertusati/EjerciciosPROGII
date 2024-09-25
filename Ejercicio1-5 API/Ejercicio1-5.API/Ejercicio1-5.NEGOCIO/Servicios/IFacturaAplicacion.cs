using Ejercicio1_5.MODELOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.NEGOCIO.Servicios
{
    public interface IFacturaAplicacion
    {
        public List<Factura> ObtenerTodos();
        public List<Factura> ObtenerTodosConFiltros(string fechaInicio, string fechaFin, int idFormaPago);
        public Factura ObtenerPorId(int id);

        public bool Nuevo(Factura articulo);
        public bool Modificar(Factura articulo);

        public bool Eliminar(int id);
    }
}
