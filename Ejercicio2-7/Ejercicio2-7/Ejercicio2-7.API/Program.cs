using Ejercicio2_7.DLL.Data.Models;
using Ejercicio2_7.DLL.Repository;
using Ejercicio2_7.DLL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DB_TURNOSContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IServicioRepository,ServicioRepository>();

builder.Services.AddScoped<ITurnoService, TurnoService>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();


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

//Tomando como base el Problema 2.7 de la Guía de Estudio U2, se pide.

//- Desarrollar una solución con un proyecto WebApi agregando los siguientes componentes:

//  	 ++Un controlador llamado ServiciosController (carpeta Controllers).

//        ++ Crear un segundo proyecto de tipo librería (DLL) que exponga los servicios para:
//        --registrar, consultar (con filtros), editar y registrar la baja lógica de servicios.

//        ++ Modificar el proyecto de tipo librería (DLL) para que exponga las funcionalidades de: registrar,
//        --consultar (con filtros), editar y registrar la baja de turnos (cancelación).


//        ++ Crear una capa de acceso a datos para incluir la gestión de servicios dentro del proyecto dll.
//        --Para ello deberá configurar debidamente las dependencias con los paquetes necesarios para trabajar con Entity Framework Core (EF).


//? Adicionalmente considerar las siguientes reglas de negocio: 

    //? La fecha del turno deberá tener como valor por defecto la fecha actual + 1 (fecha día siguiente como mínimo).
    //Deberá controlar que la fecha de reserva no supere los 45 días a la fecha actual. 

    //? Deberá controlar que no se pueden grabar dos veces el mismo servicio 
    //como detalle. Es decir, no puede solicitar “corte de cabello” 2 veces en 
    //el mismo turno. 

    //? Deberá controlar además que solo es posible registrar el turno si para 
    //la fecha y hora seleccionadas no existe un registro previamente 
    //cargado. 

    //? Controlar que se hayan ingresado datos de al menos un servicio. 

    //? Al registrar un turno se deberá retornar objeto mensaje de confirmación.  

    // Actualizar los datos de una turno siempre que la fecha/hora sean 
    //anteriores a los confirmados en su creación 

    // Cancelar una turno indicando un motivo de cancelación. Al igual que 
    //el apartado anterior, validar la restricción temporal.

    // Actualizar el modelo de datos con los campos: fecha_cancelación y 
    //motivo_cancelación en la tabla turnos. 




