using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.ListasPadrao;

namespace SistemaGestaoCompras.Application.UseCases.ListasPadrao
{
    public class CriarListaPadraoUseCase
    {
        private readonly IListaDeComprasPadraoRepositorio _repositorio;

        public CriarListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Guid> ExecutarAsync(CriarListaPadraoDto dto)
        {
            var lista = new ListaDeCompraPadrao(dto.IdUsuario, dto.Nome);

            await _repositorio.AdicionarAsync(lista);

            return lista.Id;
        }
    }
}