using System.Collections.Generic;
using System.Linq;

namespace Domain.Entidades;

public class Carrinho
{
    public int IdCarrinho { get; set; }
    public int IdProduto { get; set; }
    public Cliente Cliente { get; set; } = new Cliente();
    public int ClienteId { get; set; }
    public List<ItemCarrinho> ListaItensCarrinho { get; set; } = new();
    public decimal CalcularTotal()

    {
        return ListaItensCarrinho.Sum(item => item.SubTotal);
    }

    /*public void AdicionarProduto(Produto produto, int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            ListaItens.Add(produto);
        }
    }*/

}
