using Domain.Entidades;
namespace Application.DTOs;

public class PedidoDTO
{
    public int IdPedido { get; set; }
    public List<PedidoItensDTO> ListaItensPedido { get; set; } = new();

    public Pedido Mapear()
    {
        return new Pedido
        {
            IdPedido = this.IdPedido,
            ListaItensPedido = this.ListaItensPedido.Select(item => item.Mapear()).ToList()
        };
    }
}
