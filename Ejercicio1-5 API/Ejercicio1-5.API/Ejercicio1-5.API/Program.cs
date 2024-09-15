var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//Tomando el dominio del Problema 1.5 de la guía de estudios correspondiente a la unidad temática N° 1, se pide:

//-Crear un Proyecto Web API con la siguiente estructura de carpetas:

//  --proyecto[Practica02]:

//	++Un controlador llamado ArticulosController (carpeta Controllers).

//        ++ Un Modelo llamado Articulo (carpeta Models)

//        ++ Una implementación de una interfaz IAplicacion que exponga los servicios para: agregar, consultar, editar y registrar la baja de artículos

//        ++ Modelar una capa de acceso a datos que permita, mediante procedimientos almacenados, gestionar artículos (utilizar patrón Repository). 

//           Puede utilizar un segundo proyecto de tipo Librería (dll) para modelar esta capa. No olvide indicar la dependencia de proyecto desde la WebApi

//           al proyecto de tipo librería.

//- Utilizar la misma base de datos de la actividad 01

//- Desarrollar el/los procedimientos almacenados que considere necesarios.

//- Adicionalmente deberá probar la WebApi mediante la herramienta Swagger.