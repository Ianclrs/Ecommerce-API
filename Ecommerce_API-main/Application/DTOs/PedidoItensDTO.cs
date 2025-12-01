using Domain.Entidades;

namespace Application.DTOs;

public class PedidoItensDTO
{
    public int IdItem { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public PedidoItens Mapear()
    {
        return new PedidoItens
        {
            IdProduto = this.ProdutoId,
            Quantidade = this.Quantidade
        };
    }
}
