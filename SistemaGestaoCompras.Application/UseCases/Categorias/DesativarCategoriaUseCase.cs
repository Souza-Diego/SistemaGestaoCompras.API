using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Categorias
{
    public class DesativarCategoriaUseCase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public DesativarCategoriaUseCase(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task ExecutarAsync(Guid id)
        {
            var categoria = await _categoriaRepositorio.BuscarPorIdAsync(id);

            if (categoria == null)
                throw new Exception("Categoria não encontrada");

            categoria.Desativar();
            await _categoriaRepositorio.AtualizarAsync(categoria);
        }
    }
}