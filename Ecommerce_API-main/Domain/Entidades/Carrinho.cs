using System.Collections.Generic;
using System.Linq;

namespace Domain.Entidades;

public class Carrinho
{
    public int IdCarrinho { get; set; }
    public int ClienteId { get; set; }
    public List<ItemCarrinho> ListaItensCarrinho { get; set; } = new();
    public decimal Total = 0m;
}
