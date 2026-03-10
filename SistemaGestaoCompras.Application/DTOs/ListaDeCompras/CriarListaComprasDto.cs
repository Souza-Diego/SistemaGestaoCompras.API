namespace SistemaGestaoCompras.Application.DTOs.ListaDeCompras
{
    public class CriarListaComprasDto
    {
        public string Nome { get; set; } = string.Empty;
        public Guid? IdUsuario { get; set; }
        public Guid? IdGrupo { get; set; }
    }
}
