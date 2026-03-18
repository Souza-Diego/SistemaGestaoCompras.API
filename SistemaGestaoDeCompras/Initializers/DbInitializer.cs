using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.API.Initializers
{
    public static class DbInitializer
    {
        public static async Task SeedAdminAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var repo = scope.ServiceProvider.GetRequiredService<IUsuarioRepositorio>();

            var existeAdmin = await repo.ExisteAlgumAdminAsync();

            if (!existeAdmin)
            {
                var admin = new Usuario(
                    "Administrador",
                    new Email("admin@sistema.com"),
                    new Senha("Admin@123"),
                    TipoUsuario.Administrador
                );

                await repo.AdicionarAsync(admin);
            }
        }
    }
}