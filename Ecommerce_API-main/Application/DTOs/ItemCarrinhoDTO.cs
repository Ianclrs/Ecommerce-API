using System;
using Domain.Entidades;

namespace Application.DTOs
{
    public class ItemCarrinhoDTO
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal SubTotal { get; set; }

        public ItemCarrinho Mapear()
        {
            return new ItemCarrinho
            {
                IdProduto = this.IdProduto,
                Quantidade = this.Quantidade,
                Preco = this.Preco,
                SubTotal = this.SubTotal
            };
        }
    }
}
