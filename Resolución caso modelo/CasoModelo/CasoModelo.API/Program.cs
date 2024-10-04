 using CasoModelo.DLL.Data.Models;
using CasoModelo.DLL.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBCasoModeloContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// AGREGAR REPOSITORYS
builder.Services.AddScoped<IComponenteRepository,ComponenteRepository>();
builder.Services.AddScoped<IOrdenRepository,OrdenRepository>();



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

//Definir una capa de acceso que permita consultar los componentes y 
//registrar los datos completos de una orden de producción,
//actualizarlos y eventualmente registrar la baja de una orden. Para ello 
//debe implementar un patrón Repository. 

// Definir una WebApi que permita exponer los siguientes servicios: 

// GET / ordenes: que permita consultar todas las órdenes 
//coincidentes con los filtros: fecha y estado. Recupera todas las 
//órdenes con fecha >= a la fecha recibida como parámetro. 

// POST/ordenes: registrar los datos completos de una orden de producción.

// PUT/ordenes: que permita actualizar los datos de una orden 
//identificada por Id. 

// DELETE/ordenes/{nro}: que permita actualizar la orden a estado 
//Cancelada. 

//Tener en cuenta las siguientes reglas de negocio: 

// El estado inicial de la orden es Creada. 
// La fecha de la orden no podrá ser nunca anterior a la fecha actual 

// Deberá validar los campos obligatorios según la definición de campos de tabla 
//Ordenes_produccion 

// Deberá validar que un mismo componente no puede figurar más de una vez 
//como detalle de receta. 

// Deberá validar se hayan ingresado datos de al menos como mínimo 2 
//componentes. Caso de cumplir informar con un mensaje: “El modelo debe 
//tener como mínimo dos componentes!” 

// Solo es posible registrar la baja de una orden si su estado es distinto de 
//Cancelada o Finalizada. 

// Deberá garantizar que la orden de producción siempre se graba completa o 
//no se graba. 