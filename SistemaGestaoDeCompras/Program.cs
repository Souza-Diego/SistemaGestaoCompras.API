using Microsoft.EntityFrameworkCore;
using Scrutor;
using SistemaGestaoCompras.API.Initializers;
using SistemaGestaoCompras.API.Middlewares;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Services;
using SistemaGestaoCompras.Infrastructure.Data;
using SistemaGestaoCompras.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// Configurações do Banco de Dados
// ===============================

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ===============================
// Configurações dos Repositórios
// ===============================

builder.Services.Scan(scan => scan
    .FromAssemblyOf<GrupoRepositorio>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repositorio")))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

// ===============================
// Configs. dos Domain Services
// ===============================

builder.Services.AddScoped<CalculadoraOrcamentoAutomatico>();
builder.Services.AddScoped<EstatisticasCompraService>();

// ===============================
// Configurações dos Use Cases
// ===============================

builder.Services.Scan(scan => scan
    .FromApplicationDependencies()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("UseCase")))
    .AsSelf()
    .WithScopedLifetime());

// ===============================
// Configurações dos Controllers
// ===============================

builder.Services.AddControllers();

// ===============================
// Configurações do Swagger
// ===============================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===============================
// Config. do DB Initializer
// ===============================

await DbInitializer.SeedAdminAsync(app.Services);

// ===============================
// Configurações do Middleware
// ===============================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
