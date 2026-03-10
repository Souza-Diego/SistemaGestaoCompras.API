using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Application.DTOs.Categorias;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Categorias
{
    public class CriarCategoriaUseCase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CriarCategoriaUseCase(ICategoriaRepositorio categoriaRepository)
        {
            _categoriaRepositorio = categoriaRepository;
        }
        public async Task<Guid> ExecutarAsync(CriarCategoriaDto dto)
        {
            var categoria = new Categoria(dto.Nome);
            await _categoriaRepositorio.AdicionarAsync(categoria);
            return categoria.Id;
        }
    }
}
