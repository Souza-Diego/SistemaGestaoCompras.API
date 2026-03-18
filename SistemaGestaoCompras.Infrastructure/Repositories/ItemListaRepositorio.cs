using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class ItemListaRepositorio
        : RepositorioBase<ItemLista>, IItemListaRepositorio
    {
        public ItemListaRepositorio(AppDbContext context)
            : base(context)
        {
        }
    }
}