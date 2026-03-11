using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Listas
{
    public class ListarListasDoGrupoUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;

        public ListarListasDoGrupoUseCase(IListaDeComprasRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public async Task<IEnumerable<ListaDeCompra>> ExecutarAsync(Guid grupoId)
        {
            if (grupoId == Guid.Empty)
                throw new ArgumentException("Grupo inválido.");

            return await _listaRepositorio.ListarPorGrupoIdAsync(grupoId);
        }
    }
}