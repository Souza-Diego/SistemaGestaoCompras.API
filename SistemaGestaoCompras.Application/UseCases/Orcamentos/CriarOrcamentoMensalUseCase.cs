using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Application.DTOs.Orcamentos;

namespace SistemaGestaoCompras.Application.UseCases.Orcamentos
{
    public class CriarOrcamentoMensalUseCase
    {
        private readonly IOrcamentoRepositorio _orcamentoRepositorio;

        public CriarOrcamentoMensalUseCase(IOrcamentoRepositorio orcamentoRepositorio)
        {
            _orcamentoRepositorio = orcamentoRepositorio;
        }

        public async Task ExecutarAsync(CriarOrcamentoMensalDTO dto)
        {
            var existente = await _orcamentoRepositorio.ObterPorUsuarioMesAsync(
                dto.IdUsuario,
                dto.Ano,
                dto.Mes
            );

            if (existente != null)
                throw new Exception("Já existe orçamento para este mês.");

            var orcamento = new Orcamento(
                dto.IdUsuario,
                dto.Ano,
                dto.Mes,
                new Dinheiro(dto.ValorPlanejado)
            );

            await _orcamentoRepositorio.AdicionarAsync(orcamento);
        }
    }
}