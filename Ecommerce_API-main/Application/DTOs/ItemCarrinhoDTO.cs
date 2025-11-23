using System;
using Domain.Entidades;

namespace Application.DTOs
{
    public class ItemCarrinhoDTO
    {
        public int IdItemCarrinho { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        // Precisa estar no DTO para calcular o subtotal ao retornar para cliente
        public decimal Preco { get; set; }

        // Propriedade calculada — não deve ser enviada pelo cliente como fonte de verdade
        public decimal SubTotal => Math.Round(Quantidade * Preco, 2);

        public ItemCarrinho Mapear()
        {
            return new ItemCarrinho
            {
                IdItemCarrinho = this.IdItemCarrinho,
                IdProduto = this.IdProduto,
                Quantidade = this.Quantidade,
                Preco = this.Preco
            };
        }

        // Método estático para converter de entidade para DTO
        public static ItemCarrinhoDTO FromEntity(ItemCarrinho item)
        {
            if (item == null) return null;
            return new ItemCarrinhoDTO
            {
                IdItemCarrinho = item.IdItemCarrinho,
                IdProduto = item.IdProduto,
                Quantidade = item.Quantidade,
                Preco = item.Preco
            };
        }
    }
}
