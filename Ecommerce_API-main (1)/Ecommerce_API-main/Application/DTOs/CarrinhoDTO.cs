using System.Linq;
using System.Collections.Generic;
using Domain.Entidades;
namespace Application.DTOs;

public class CarrinhoDTO
{
    public decimal Total { get; set; }
    public int IdCarrinho { get; set; }
    public int ClienteId { get; set; }
    public List<ItemCarrinhoDTO> ListaItensCarrinho { get; set; } = new();



    public Carrinho Mapear()
    {
        return new Carrinho
        {
            ClienteId = ClienteId,
            IdCarrinho = this.IdCarrinho,
            ListaItensCarrinho = this.ListaItensCarrinho.Select(item => item.Mapear()).ToList()
        };

    }
}
