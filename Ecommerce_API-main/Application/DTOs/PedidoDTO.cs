using Domain.Entidades;
namespace Application.DTOs;

public class PedidoDTO
{
    public int IdPedido { get; set; }
    public int ClienteId { get; set; }
    public List<PedidoItensDTO> ListaItensPedido { get; set; } = new();

    public Pedido Mapear()
    {
        return new Pedido
        {
            IdPedido = this.IdPedido,
            ClienteId = this.ClienteId,
            ListaItensPedido = this.ListaItensPedido.Select(item => item.Mapear()).ToList()
        };
    }
}
