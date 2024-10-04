using CasoModelo.DLL.Data.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoModelo.DLL.Data.Repository
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly DBCasoModeloContext _context;
        public OrdenRepository(DBCasoModeloContext context)
        {
            _context = context;
        }
        public List<OrdenProducion> GetAllFiltro(DateTime fechaDesde, bool estado)
        {

            return _context.OrdenesProducions
                 .Where(o => o.Fecha >= fechaDesde && o.Estado == estado)
                 .ToList();
        }

        public OrdenProducion GetOrdenProducion(int nro_orden)
        {
            return _context.OrdenesProducions.Find(nro_orden);
        }
        public bool AddOrden(OrdenProducion ordenProducion)
        {
            _context.OrdenesProducions.Add(ordenProducion);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateEstado(int nro_orden)
        {
            OrdenProducion o = GetOrdenProducion(nro_orden);
            if (o != null || o.Estado != false)
            {
                o.Estado = false;
            }
            return _context.SaveChanges() > 0;
        }

        public bool UpdateOrden(int nro_orden, DateTime fecha, int cantidad)
        {
            OrdenProducion o = GetOrdenProducion(nro_orden);
            if (o != null)
            {
                o.Fecha = fecha;
                o.Cantidad = cantidad;
            }

            return _context.SaveChanges() > 0;
        }
    }
}
