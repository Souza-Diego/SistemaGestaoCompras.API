using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.RegistroDePrecos
{
    public class ListarPrecosProdutoUseCase
    {
        private readonly IRegistroDePrecoRepositorio _repositorio;

        public ListarPrecosProdutoUseCase(IRegistroDePrecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<RegistroDePreco>> ExecutarAsync(Guid produtoId)
        {
            return await _repositorio.ObterPorProdutoAsync(produtoId);
        }
    }
}