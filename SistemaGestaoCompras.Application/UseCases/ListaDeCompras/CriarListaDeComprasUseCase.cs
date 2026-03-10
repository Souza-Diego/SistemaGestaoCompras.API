using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;

namespace SistemaGestaoCompras.Application.UseCases.ListaDeCompras
{
    public class CriarListaDeComprasUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;

        public CriarListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public async Task<Guid> ExecutarAsync(CriarListaComprasDto dto)
        {
            ListaDeCompra lista;

            if (dto.IdUsuario.HasValue)
            {
                lista = new ListaDeCompra(dto.Nome, dto.IdUsuario.Value);
            }
            else if (dto.IdGrupo.HasValue)
            {
                lista = new ListaDeCompra(dto.Nome, dto.IdGrupo.Value, true);
            }
            else
            {
                throw new ArgumentException("A lista precisa pertencer a um usuário ou a um grupo.");
            }

            await _listaRepositorio.AdicionarAsync(lista);

            return lista.Id;
        }
    }
}