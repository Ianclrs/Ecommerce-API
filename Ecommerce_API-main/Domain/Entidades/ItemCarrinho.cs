using System;
namespace Domain.Entidades;

public class ItemCarrinho
{
	public int IdItemCarrinho { get; set; }
	public int IdProduto { get; set; }
	public int Quantidade { get; set; }

	public decimal Preco = 0m;

	public decimal SubTotal = 0;

}

