using SistemaGestaoCompras.Application.DTOs.Categorias;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Categorias
{
    public class AtualizarCategoriaUseCase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public AtualizarCategoriaUseCase(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task ExecutarAsync(AtualizarCategoriaDto dto)
        {
            var categoria = await _categoriaRepositorio.BuscarPorIdAsync(dto.Id);

            if (categoria == null)
                throw new Exception("Categoria não encontrada");

            categoria.AlterarNome(dto.Nome);

            await _categoriaRepositorio.AtualizarAsync(categoria);
        }
    }
}
