namespace Domain.Entidades;
public class PedidoItens
{
	public int IdPedido { get; set; }
	public int IdProduto { get; set; }
	public int Quantidade { get; set; }
	public decimal Preco { get; set; }
}
