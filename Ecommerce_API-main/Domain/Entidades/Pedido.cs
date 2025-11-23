namespace Domain.Entidades;
public class Pedido
{
    public int IdProduto { get; set; }
    public int IdPedido { get; set; }
    public Cliente Cliente { get; set; } = new Cliente();
    public int ClienteId { get; set; }
    public List<PedidoItens> ListaItensPedido { get; set; } = new();
}
