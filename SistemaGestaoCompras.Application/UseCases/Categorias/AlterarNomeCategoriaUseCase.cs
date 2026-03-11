using SistemaGestaoCompras.Application.DTOs.Categorias;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Categorias
{
    public class AlterarNomeCategoriaUseCase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public AlterarNomeCategoriaUseCase(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task ExecutarAsync(AlterarNomeCategoriaDto dto)
        {
            var categoria = await _categoriaRepositorio.BuscarPorIdAsync(dto.Id);

            if (categoria == null)
                throw new Exception("Categoria não encontrada");

            categoria.AlterarNome(dto.Nome);

            await _categoriaRepositorio.AtualizarAsync(categoria);
        }
    }
}
