using SistemaGestaoCompras.Application.DTOs.Orcamentos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Orcamentos
{
    public class ObterOrcamentoDoMesUseCase
    {
        private readonly IOrcamentoRepositorio _orcamentoRepositorio;

        public ObterOrcamentoDoMesUseCase(IOrcamentoRepositorio orcamentoRepositorio)
        {
            _orcamentoRepositorio = orcamentoRepositorio;
        }

        public async Task<OrcamentoDto?> ExecutarAsync(ObterOrcamentoDoMesDTO dto)
        {
            var orcamento = await _orcamentoRepositorio.ObterPorUsuarioMesAsync(
                dto.IdUsuario,
                dto.Ano,
                dto.Mes
            );

            if (orcamento == null)
                return null;

            return new OrcamentoDto
            {
                Id = orcamento.Id,
                Ano = orcamento.Ano,
                Mes = orcamento.Mes,
                ValorPlanejado = orcamento.ValorPlanejado.Valor
            };
        }
    }
}