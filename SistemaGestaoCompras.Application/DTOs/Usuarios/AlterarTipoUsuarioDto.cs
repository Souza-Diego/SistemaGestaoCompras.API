using SistemaGestaoCompras.Domain.Enums;

public class AlterarTipoUsuarioDto
{    
    public Guid IdUsuarioAlvo { get; set; }
    public TipoUsuario NovoTipo { get; set; }
    public Guid IdUsuarioRequisitante { get; set; }

}