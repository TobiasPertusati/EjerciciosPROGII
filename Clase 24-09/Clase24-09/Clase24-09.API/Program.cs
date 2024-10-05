using Clase24_09.DLL.Data.Repository;
using Clase24_09.DLL.Entities.Models;
using Clase24_09.DLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DB_TURNOSContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]);
});

// add services
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
//builder.Services.AddTransient<ITurnoService, TurnoService>();
builder.Services.AddScoped<ITurnoService, TurnoService>();

//


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
