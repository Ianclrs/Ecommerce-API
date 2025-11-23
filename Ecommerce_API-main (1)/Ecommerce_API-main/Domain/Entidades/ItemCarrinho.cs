using System;
namespace Domain.Entidades;

public class ItemCarrinho
{
	public int IdItemCarrinho { get; set; }
	public int IdProduto { get; set; }
	public int Quantidade { get; set; }
	public decimal Preco { get; set; }
    // Propriedade calculada para obter o subtotal do item no carrinho
    public decimal SubTotal => Preco * Quantidade;

}

