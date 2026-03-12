using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Application.DTOs.Orcamentos;

namespace SistemaGestaoCompras.Application.UseCases.Orcamentos
{
    public class AlterarValorOrcamentoUseCase
    {
        private readonly IOrcamentoRepositorio _orcamentoRepositorio;

        public AlterarValorOrcamentoUseCase(IOrcamentoRepositorio orcamentoRepositorio)
        {
            _orcamentoRepositorio = orcamentoRepositorio;
        }

        public async Task ExecutarAsync(AlterarValorOrcamentoDTO dto)
        {
            var orcamento = await _orcamentoRepositorio.BuscarPorIdAsync(dto.IdOrcamento);

            if (orcamento == null)
                throw new Exception("Orçamento não encontrado.");

            orcamento.AlterarValor(new Dinheiro(dto.NovoValor));

            await _orcamentoRepositorio.AtualizarAsync(orcamento);
        }
    }
}