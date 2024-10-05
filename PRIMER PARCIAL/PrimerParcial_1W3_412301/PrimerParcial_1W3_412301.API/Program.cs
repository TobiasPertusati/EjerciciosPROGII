using Microsoft.EntityFrameworkCore;
using PrimerParcial_1W3_412301.DLL.Data.Models;
using PrimerParcial_1W3_412301.DLL.Data.Repository;
using PrimerParcial_1W3_412301.DLL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<db_criptomonedasContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));


// add repositorys & services
builder.Services.AddScoped<ICriptomonedaRepository, CriptomonedaRepository>();
builder.Services.AddScoped<ICriptomonedaService, CriptomonedaService>();


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
