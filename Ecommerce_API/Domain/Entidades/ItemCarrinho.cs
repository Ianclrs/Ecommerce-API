namespace Domain.Entidades;

public class ItemCarrinho
{
	public int IdCarrinho { get; set; }
	public int IdProduto { get; set; }
	public int Quantidade { get; set; }
	public decimal Preco { get; set; }
}
