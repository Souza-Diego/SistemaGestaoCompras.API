using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Infrastructure.Data;
using SistemaGestaoCompras.Infrastructure.Repositories;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using Scrutor;

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

builder.Services.AddScoped<IGrupoRepositorio, GrupoRepositorio>();
builder.Services.AddScoped<IConviteGrupoRepositorio, ConviteGrupoRepositorio>();
//builder.Services.AddScoped<ICompraRepositorio, CompraRepositorio>();
builder.Services.AddScoped<IListaDeComprasRepositorio, ListaDeComprasRepositorio>();
//builder.Services.AddScoped<IListaDeComprasPadraoRepositorio, ListaDeComprasPadraoRepositorio>();
//builder.Services.AddScoped<IOrcamentoRepositorio, OrcamentoRepositorio>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
//builder.Services.AddScoped<IRegistroDePrecoRepositorio, RegistroDePrecoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IMercadoRepositorio, MercadoRepositorio>();
builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

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
// Configurações do Middleware
// ===============================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
