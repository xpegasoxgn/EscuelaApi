using EscuelaApi.Infraestructura.Conexiones;
using EscuelaApi.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. Registro de Servicios en el Contenedor (IoC)
// ==========================================

builder.Services.AddControllers();

// Configuración de OpenAPI / Swagger para documentación de endpoints
builder.Services.AddOpenApi();

// Lectura de la cadena de conexión desde appsettings.json
var cadenaConexion = builder.Configuration.GetConnectionString("EscuelaBD");

// Registro del DbContext de Entity Framework Core con el proveedor de SQL Server
builder.Services.AddDbContext<EscuelaDbContext>(options =>
{
    options.UseSqlServer(cadenaConexion);
});

// Registro de los Servicios de Negocio con ciclo de vida Scoped (una instancia por petición HTTP)
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();

// ==========================================
// 2. Construcción de la Aplicación y Pipeline HTTP
// ==========================================

var app = builder.Build();

// Configurar documentación interactiva en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeo automático de las rutas de todos los controladores
app.MapControllers();

app.Run();
