using EscuelaApi.Infrastructura.Conexiones;
using EscuelaApi.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//leer la cadena de conexion desde appsettings.json
var cadenaConexion = builder.Configuration.GetConnectionString("EscuelaBD");
//registra el contexto para que los controladores puedan recibirlo

builder.Services.AddDbContext<EscuelaDbContext>(options =>
{
    options.UseSqlServer(cadenaConexion);
});

builder.Services.AddDbContext<EscuelaDbContext>(options => { options.UseSqlServer(cadenaConexion); });
//cuando  el controlador pida la interfaz  intregarle la impletacion
builder.Services.AddScoped<IEstudianteService, EstudianteService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
