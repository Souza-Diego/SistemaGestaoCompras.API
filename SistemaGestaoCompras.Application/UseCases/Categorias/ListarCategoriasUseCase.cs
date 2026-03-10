using SistemaGestaoCompras.Application.DTOs.Categorias;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Categorias
{
    public class ListarCategoriasUseCase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public ListarCategoriasUseCase(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<IEnumerable<CategoriaDto>> ExecutarAsync()
        {
            var categorias = await _categoriaRepositorio.ListarAtivosAsync();

            return categorias.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Ativo = c.Ativo
            });
        }
    }
}