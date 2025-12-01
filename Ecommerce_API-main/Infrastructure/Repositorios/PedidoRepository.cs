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
    public class PedidoRepository : IPedidoRepository
    {
        public void Incluir(Pedido pedido)
        {
            BancoSql.ListaPedidos.Add(pedido);
        }

        public List<Pedido> Listar()
        {
            return BancoSql.ListaPedidos.ToList();
        }

        public void Remover(int id)
        {
            Pedido? pedido = BancoSql.ListaPedidos.FirstOrDefault(p => p.IdPedido == id);
            if (pedido != null)
            {
                BancoSql.ListaPedidos.Remove(pedido);
            }
        }
    }
}
