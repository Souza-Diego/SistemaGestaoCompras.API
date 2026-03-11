public class AlterarUnidadeItemListaDto
{
    public Guid IdListaDeCompras { get; set; }
    public Guid IdItem { get; set; }
    public string UnidadeSimbolo { get; set; } = null!;
}