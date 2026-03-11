namespace SistemaGestaoCompras.Application.DTOs.ListaDeCompras
{
    public class CriarListaAPartirDeTemplateDto
    {
        public Guid IdListaPadrao { get; set; }
        public string NomeNovaLista { get; set; } = string.Empty;
        public Guid? IdUsuario { get; set; }
        public Guid? IdGrupo { get; set; }
    }
}