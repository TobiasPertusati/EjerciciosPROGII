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


using Ejercicio1_5.Servicios;

Console.WriteLine("LISTAR TODAS LAS FACTURAS, CON DETALLE");
FacturaService facturaService = new FacturaService();
foreach (var fac in facturaService.GetAll())
{
    Console.WriteLine(fac);
}
Console.WriteLine("---------------------------------");
