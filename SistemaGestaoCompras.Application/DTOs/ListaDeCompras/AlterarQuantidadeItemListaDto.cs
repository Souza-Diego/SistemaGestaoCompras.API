public class AlterarQuantidadeItemListaDto
{
    public Guid IdListaDeCompras { get; set; }
    public Guid IdItem { get; set; }
    public decimal NovaQuantidade { get; set; }
}