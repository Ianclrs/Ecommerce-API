using System.Linq;
using System.Collections.Generic;
using Domain.Entidades;
namespace Application.DTOs;

public class CarrinhoDTO
{
    public int ClienteId { get; set; }
    public List<ItemCarrinhoDTO> ListaItensCarrinho { get; set; } = new();
    public decimal Total { get; set; }


    public Carrinho Mapear()
    {
        return new Carrinho
        {
            ClienteId = this.ClienteId,
            Total = this.Total,
            ListaItensCarrinho = this.ListaItensCarrinho.Select(item => item.Mapear()).ToList()
        };

    }
}
