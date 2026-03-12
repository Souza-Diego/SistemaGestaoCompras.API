using SistemaGestaoCompras.Application.DTOs.RegistroDePrecos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.RegistroDePrecos
{
    public class CorrigirPrecoRegistradoUseCase
    {
        private readonly IRegistroDePrecoRepositorio _repositorio;

        public CorrigirPrecoRegistradoUseCase(IRegistroDePrecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task ExecutarAsync(CorrigirPrecoRegistradoDto dto)
        {
            var registro = await _repositorio.BuscarPorIdAsync(dto.IdRegistro);

            if (registro == null)
                throw new Exception("Registro de preço não encontrado.");

            registro.CorrigirPreco(new Dinheiro(dto.NovoPreco));

            await _repositorio.AtualizarAsync(registro);
        }
    }
}
