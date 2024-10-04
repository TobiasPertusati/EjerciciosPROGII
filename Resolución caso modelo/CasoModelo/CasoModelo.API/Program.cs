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
//registrar los datos completos de una orden de producci�n,
//actualizarlos y eventualmente registrar la baja de una orden. Para ello 
//debe implementar un patr�n Repository. 

// Definir una WebApi que permita exponer los siguientes servicios: 

// GET / ordenes: que permita consultar todas las �rdenes 
//coincidentes con los filtros: fecha y estado. Recupera todas las 
//�rdenes con fecha >= a la fecha recibida como par�metro. 

// POST/ordenes: registrar los datos completos de una orden de producci�n.

// PUT/ordenes: que permita actualizar los datos de una orden 
//identificada por Id. 

// DELETE/ordenes/{nro}: que permita actualizar la orden a estado 
//Cancelada. 

//Tener en cuenta las siguientes reglas de negocio: 

// El estado inicial de la orden es Creada. 
// La fecha de la orden no podr� ser nunca anterior a la fecha actual 

// Deber� validar los campos obligatorios seg�n la definici�n de campos de tabla 
//Ordenes_produccion 

// Deber� validar que un mismo componente no puede figurar m�s de una vez 
//como detalle de receta. 

// Deber� validar se hayan ingresado datos de al menos como m�nimo 2 
//componentes. Caso de cumplir informar con un mensaje: �El modelo debe 
//tener como m�nimo dos componentes!� 

// Solo es posible registrar la baja de una orden si su estado es distinto de 
//Cancelada o Finalizada. 

// Deber� garantizar que la orden de producci�n siempre se graba completa o 
//no se graba. 