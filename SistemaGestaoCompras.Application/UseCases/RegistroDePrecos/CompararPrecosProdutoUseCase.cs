using SistemaGestaoCompras.Application.DTOs.RegistroDePrecos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.RegistroDePrecos
{
    public class CompararPrecosProdutoUseCase
    {
        private readonly IRegistroDePrecoRepositorio _repositorio;

        public CompararPrecosProdutoUseCase(IRegistroDePrecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<ComparacaoPrecoDto>> ExecutarAsync(Guid produtoId)
        {
            var registros = await _repositorio.ObterPorProdutoAsync(produtoId);

            return registros
                .OrderBy(r => r.Preco.Valor)
                .Select(r => new ComparacaoPrecoDto
                {
                    MercadoId = r.IdMercado,
                    Preco = r.Preco.Valor,
                    QuantidadeReferencia = r.QuantidadeReferencia,
                    UnidadeReferencia = r.UnidadeReferencia.Simbolo,
                    DataRegistro = r.DataRegistro
                });
        }
    }
}