using FinalBackendWeb.DAO;
using FinalBackendWeb.Interfaces;
using FinalBackendWeb.Services;
using Microsoft.EntityFrameworkCore;
using FinalBackendWeb.DAO;
using FinalBackendWeb.Interfaces;
using FinalBackendWeb.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de Dependencias
builder.Services.AddScoped<IPreguntaService, PreguntaService>();
builder.Services.AddScoped<IRespuestaService, RespuestaService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();
app.MapControllers();
app.Run();