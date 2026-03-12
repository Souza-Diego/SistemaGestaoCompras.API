using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.RegistroDePrecos
{
    public class ObterMelhorPrecoProdutoUseCase
    {
        private readonly IRegistroDePrecoRepositorio _repositorio;

        public ObterMelhorPrecoProdutoUseCase(IRegistroDePrecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<RegistroDePreco?> ExecutarAsync(Guid produtoId)
        {
            var registros = await _repositorio.ObterPorProdutoAsync(produtoId);

            return registros
                .OrderBy(r => r.Preco.Valor / r.QuantidadeReferencia)
                .FirstOrDefault();
        }
    }
}