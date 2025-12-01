using Domain.Entidades;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorios
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        public void AdicionarCarrinho(Carrinho carrinho)
        {
            BancoSql.ListaCarrinhos.Add(carrinho);
        }
        public void Remover(int id)
        {
            Carrinho? carrinho = BancoSql.ListaCarrinhos.FirstOrDefault(c => c.IdCarrinho == id);
            if (carrinho != null) BancoSql.ListaCarrinhos.Remove(carrinho);
        }

        public void AdicionarItem(int idCarrinho, ItemCarrinho item)
        {
            Carrinho? carrinho = BancoSql.ListaCarrinhos.FirstOrDefault(c => c.IdCarrinho == idCarrinho);
            if (carrinho != null)
            {
                carrinho.ListaItensCarrinho.Add(item);
            }
        }

        public void RemoverItem(int idCarrinho, int idItem)
        {
            Carrinho? carrinho = BancoSql.ListaCarrinhos.FirstOrDefault(c => c.IdCarrinho == idCarrinho);
            if (carrinho != null)
            {
                ItemCarrinho? item = carrinho.ListaItensCarrinho.FirstOrDefault(i => i.IdProduto == idItem);
                if (item != null)
                {
                    carrinho.ListaItensCarrinho.Remove(item);
                }
            }
        }

        public void SubtrairQuantidadeItem(int idCarrinho, int idItem, int decrescimo)
        {
            Carrinho? carrinho = BancoSql.ListaCarrinhos.FirstOrDefault(c => c.IdCarrinho == idCarrinho);
            if (carrinho != null)
            {
                ItemCarrinho? item = carrinho.ListaItensCarrinho.FirstOrDefault(i => i.IdItemCarrinho == idItem);
                if (item != null)
                {
                    item.Quantidade -= decrescimo;
                    if (item.Quantidade < 0)
                    {
                        item.Quantidade = 0;
                    }
                }
            }
        }

        public List<Carrinho> Listar()
        {
            return BancoSql.ListaCarrinhos.ToList();
        }

        public List<ItemCarrinho> ListarItensCarrinho(int idCarrinho)
        {
            Carrinho? carrinho = BancoSql.ListaCarrinhos.FirstOrDefault(c => c.IdCarrinho == idCarrinho);
            if (carrinho != null)
            {
                return carrinho.ListaItensCarrinho.ToList();
            }
            return new List<ItemCarrinho>();
        }
    }
}
