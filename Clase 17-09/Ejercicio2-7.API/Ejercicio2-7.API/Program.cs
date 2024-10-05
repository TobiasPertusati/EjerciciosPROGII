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


//Definir una capa de datos que permita consultar servicios y registrar los datos 
//completos de un turno con el detalle de servicios. Implementar el patrón 
//repository tanto para turnos como para servicios.
// Cada repositorio deberá llamar a los procedimientos almacenados provistos 
//en el script.
// Adicionalmente considerar las siguientes reglas de negocio:
// La fecha de reserva deberá tener como valor por defecto la fecha actual 
//+ 1 (fecha día siguiente como mínimo). Deberá controlar que la fecha 
//de reserva no supere los 45 días a la fecha actual.
//Deberá controlar que no se pueden grabar dos veces el mismo servicio 
//como detalle. Es decir, no puede solicitar “corte de cabello” 2 veces en 
//el mismo turno.
// Deberá controlar además que solo es posible registrar el turno si para 
//la fecha y hora seleccionadas no existe un registro previamente 
//cargado.
// Controlar que se hayan ingresado datos de al menos un servicio.
// Al registrar un turno se deberá retornar objeto mensaje de confirmación.
// Crear una colección POSTMAN que permita probar las funcionalidades para 
//consultar servicios y registrar los datos completos de un turno
