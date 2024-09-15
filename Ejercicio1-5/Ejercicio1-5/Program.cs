//Conceptos avanzados de POO, uso de interfaces
//Tomando como base el Problema 1.5 de la guía de estudios correspondiente a la unidad temática N° 1, se pide:

//-Crear un Proyecto de Consola con la siguiente estructura de carpetas:

//  --proyecto[Practica01]:

//	++dominio: clases del dominio de problema 

//	++ datos: con la/s interfaces y clases concretas para los repositorios de datos

//  ++ servicios: con las clases de servicio necesarias para gestionar el CRUD de la entidad principal del problema

//- Crear una base de datos con la tabla de transacción y la/s de soporte.

//- Desarrollar el/los procedimientos almacenados que considere para las operaciones de consulta y actualización tanto de tablas transaccionales como las de soporte.
// Utilizar los componentes ADO.NET desde C#

//- Adicionalmente deberá incluir una clase Program que permita ejecutar los métodos de servicio definidos en la capa de negocio, mostrando las salidas por consola.

//Deberá controlar que, si un mismo artículo se agrega más de una vez,
//se deberá incrementar las cantidades del mismo detalle.


using Ejercicio1_5.Dominio;
using Ejercicio1_5.Servicios;


// nota el program solo va a funcionar correctamente con el script de la db creado por mi
// y ademas solo la primera vez que se ejecute
// despues de eso se deberan cambiar los datos a mano para obtener los resultados esperados.
public static class Program
{
    public static void Main()
    {
        FacturaService _facturaService = new FacturaService();
        List<Factura> facturas = _facturaService.GetAll();


        Console.WriteLine("LISTAR TODAS LAS FACTURAS, CON SUS RESPECTIVOS DETALLES\n");
        foreach (Factura factura in facturas)
        {
            Console.WriteLine(factura);
            Console.WriteLine("\n");
        }

        Console.WriteLine("AGREGAR UNA NUEVA FACTURA CON SUS DETALLES");
        Factura f3 = new Factura()
        {
            Cliente = "Juancito Muzz",
            Fecha = DateTime.Now,
            FormaPago = new FormaPago()
            {
                IdFormaPago = 1,
            },
            Detalles = new List<DetalleFactura>()
            {
                new DetalleFactura()
                {
                    Articulo = new Articulo()
                    {
                        IdArticulo = 1,
                    },
                    Cantidad = 4
                },
                new DetalleFactura()
                {
                    Articulo = new Articulo()
                    {
                        IdArticulo = 2,
                    },
                    Cantidad = 1
                },
            }
        };
        if (_facturaService.Create(f3))
        {
            Console.WriteLine("se creo la factura con exito");
            f3 = _facturaService.GetById(3);
            Console.WriteLine(f3);
        }
        else
            Console.WriteLine("no se pudo crear la factura");


        Console.WriteLine("MODIFICAR UNA FACTURA, ALTERANDO ALGUNO DE SUS DETALLES , ELIMINANDO ALGUNO Y CREANDO NUEVOS\n");

        f3.FormaPago.IdFormaPago = 2;
        f3.Cliente = "Lebron James";
        f3.Detalles.RemoveAt(1);
        f3.Detalles[0].Cantidad = 15;
        DetalleFactura d1 = new DetalleFactura()
        {
            Articulo = new Articulo()
            {
                IdArticulo = 4,
            },
            Cantidad = 4
        };
        DetalleFactura d2 = new DetalleFactura()
        {
            Articulo = new Articulo()
            {
                IdArticulo = 3,
            },
            Cantidad = 7
        };
        f3.Detalles.Add(d1);
        f3.Detalles.Add(d2);
        if (_facturaService.Update(f3))
            Console.WriteLine("Se modifico la factura con exito");
        else
            Console.WriteLine("No se pudo modificar la factura");
        Console.WriteLine(_facturaService.GetById(3));



        Console.WriteLine("ELIMINAR UNA FACTURA, Y TODOS SUS DETALLES ASOCIADOS");
        if (_facturaService.Delete(3))
            Console.WriteLine("Se elimino la factura con exito");
        else
            Console.WriteLine("No se pudo eliminar la factura");

    }
}