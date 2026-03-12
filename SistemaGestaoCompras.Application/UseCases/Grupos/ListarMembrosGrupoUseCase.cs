using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Exceptions;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class ListarMembrosGrupoUseCase
{
    private readonly IGrupoRepositorio _repositorio;

    public ListarMembrosGrupoUseCase(IGrupoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<GrupoUsuario>> ExecutarAsync(Guid grupoId)
    {
        var grupo = await _repositorio.BuscarPorIdAsync(grupoId);

        if (grupo == null)
            throw new NotFoundException("Grupo", grupoId);

        return grupo.Membros;
    }
}