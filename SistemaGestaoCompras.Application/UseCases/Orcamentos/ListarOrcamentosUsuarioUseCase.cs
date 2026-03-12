using SistemaGestaoCompras.Application.DTOs.Orcamentos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Orcamentos
{
    public class ListarOrcamentosUsuarioUseCase
    {
        private readonly IOrcamentoRepositorio _orcamentoRepositorio;

        public ListarOrcamentosUsuarioUseCase(IOrcamentoRepositorio orcamentoRepositorio)
        {
            _orcamentoRepositorio = orcamentoRepositorio;
        }

        public async Task<IEnumerable<OrcamentoDto>> ExecutarAsync(Guid usuarioId)
        {
            var orcamentos = await _orcamentoRepositorio.ObterPorUsuarioAsync(usuarioId);

            return orcamentos.Select(o => new OrcamentoDto
            {
                Id = o.Id,
                Ano = o.Ano,
                Mes = o.Mes,
                ValorPlanejado = o.ValorPlanejado.Valor
            });
        }
    }
}