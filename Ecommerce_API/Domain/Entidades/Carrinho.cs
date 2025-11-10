namespace Domain.Entidades;

public class Carrinho
{
    public int Id { get; set; }
    public List<ItemCarrinho> ListaItens { get; set; } = new();
}
