using SistemaGestaoCompras.Application.DTOs.RegistroDePrecos;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.RegistroDePrecos
{
    public class RegistrarPrecoProdutoUseCase
    {
        private readonly IRegistroDePrecoRepositorio _repositorio;

        public RegistrarPrecoProdutoUseCase(IRegistroDePrecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Guid> ExecutarAsync(RegistrarPrecoProdutoDto dto)
        {
            var unidade = UnidadeMedida.ObterPorSimbolo(dto.UnidadeReferencia);

            var registro = new RegistroDePreco(
                dto.IdProduto,
                dto.IdMercado,
                dto.IdUsuario,
                new Dinheiro(dto.Preco),
                dto.QuantidadeReferencia,
                unidade
            );

            await _repositorio.AdicionarAsync(registro);

            return registro.Id;
        }
    }
}
