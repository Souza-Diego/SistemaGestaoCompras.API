using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Listas
{
    public class ListarListasDoUsuarioUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;

        public ListarListasDoUsuarioUseCase(IListaDeComprasRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public async Task<IEnumerable<ListaDeCompra>> ExecutarAsync(Guid usuarioId)
        {
            if (usuarioId == Guid.Empty)
                throw new ArgumentException("Usuário inválido.");

            return await _listaRepositorio.ListarPorUsuarioIdAsync(usuarioId);
        }
    }
}