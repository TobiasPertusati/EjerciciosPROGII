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

//Tomando como base el Problema 2.7 de la Gu�a de Estudio U2, se pide.

//- Desarrollar una soluci�n con un proyecto WebApi agregando los siguientes componentes:

//  	 ++Un controlador llamado ServiciosController (carpeta Controllers).

//        ++ Crear un segundo proyecto de tipo librer�a (DLL) que exponga los servicios para:
//        --registrar, consultar (con filtros), editar y registrar la baja l�gica de servicios.

//        ++ Modificar el proyecto de tipo librer�a (DLL) para que exponga las funcionalidades de: registrar,
//        --consultar (con filtros), editar y registrar la baja de turnos (cancelaci�n).


//        ++ Crear una capa de acceso a datos para incluir la gesti�n de servicios dentro del proyecto dll.
//        --Para ello deber� configurar debidamente las dependencias con los paquetes necesarios para trabajar con Entity Framework Core (EF).


//? Adicionalmente considerar las siguientes reglas de negocio: 

    //? La fecha del turno deber� tener como valor por defecto la fecha actual + 1 (fecha d�a siguiente como m�nimo).
    //Deber� controlar que la fecha de reserva no supere los 45 d�as a la fecha actual. 

    //? Deber� controlar que no se pueden grabar dos veces el mismo servicio 
    //como detalle. Es decir, no puede solicitar �corte de cabello� 2 veces en 
    //el mismo turno. 

    //? Deber� controlar adem�s que solo es posible registrar el turno si para 
    //la fecha y hora seleccionadas no existe un registro previamente 
    //cargado. 

    //? Controlar que se hayan ingresado datos de al menos un servicio. 

    //? Al registrar un turno se deber� retornar objeto mensaje de confirmaci�n.  

    // Actualizar los datos de una turno siempre que la fecha/hora sean 
    //anteriores a los confirmados en su creaci�n 

    // Cancelar una turno indicando un motivo de cancelaci�n. Al igual que 
    //el apartado anterior, validar la restricci�n temporal.

    // Actualizar el modelo de datos con los campos: fecha_cancelaci�n y 
    //motivo_cancelaci�n en la tabla turnos. 




