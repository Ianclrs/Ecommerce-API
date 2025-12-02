namespace Domain.Entidades;
public class Pedido
{
    public int IdPedido { get; set; }
    public int ClienteId { get; set; }
    public List<PedidoItens> ListaItensPedido { get; set; } = new();
}
