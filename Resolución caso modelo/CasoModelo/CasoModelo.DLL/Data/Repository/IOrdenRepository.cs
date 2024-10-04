using CasoModelo.DLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoModelo.DLL.Data.Repository
{
    public interface IOrdenRepository
    {


        // GET / ordenes: que permita consultar todas las órdenes 
        //coincidentes con los filtros: fecha y estado. Recupera todas las 
        //órdenes con fecha >= a la fecha recibida como parámetro. 

        List<OrdenProducion> GetAllFiltro(DateTime fechaDesde, bool estado);



        // POST/ordenes: registrar los datos completos de una orden de 
        //producción. El estado inicial de la orden es Creada. 

        bool AddOrden(OrdenProducion ordenProducion);


        // PUT/ordenes: que permita actualizar los datos de una orden 
        //identificada por Id. 

        bool UpdateOrden(int nro_orden, DateTime fecha, int cantidad);


        // DELETE/ordenes/{nro}: que permita actualizar la orden a estado 
        //Cancelada. 
        bool UpdateEstado(int nro_orden);

        OrdenProducion GetOrdenProducion(int nro_orden);




    }
}
