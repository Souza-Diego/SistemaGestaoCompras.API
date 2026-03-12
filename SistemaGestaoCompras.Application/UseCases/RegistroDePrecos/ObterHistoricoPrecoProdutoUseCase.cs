using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.RegistroDePrecos
{
    public class ObterHistoricoPrecoProdutoUseCase
    {
        private readonly IRegistroDePrecoRepositorio _repositorio;

        public ObterHistoricoPrecoProdutoUseCase(IRegistroDePrecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<RegistroDePreco>> ExecutarAsync(Guid produtoId)
        {
            var registros = await _repositorio.ObterPorProdutoAsync(produtoId);

            return registros
                .OrderByDescending(r => r.DataRegistro);
        }
    }
}