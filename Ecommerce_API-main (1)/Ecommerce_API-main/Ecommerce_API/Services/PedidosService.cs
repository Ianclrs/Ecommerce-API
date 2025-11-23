using Application.DTOs;
using Domain.Entidades;
using Domain.Interfaces;
using Domain.Helpers;

namespace Application.DTOs;

public class PedidosService
{
    private IPedidoRepository _pedidoRepository;
    public PedidosService(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }
    public void Incluir(PedidoDTO pedidoDTO)
    {
        try 
        {
            if (pedidoDTO == null)
                throw new DomainException("O pedido não pode ser nulo.");
            else if (pedidoDTO.ListaItensPedido == null || !pedidoDTO.ListaItensPedido.Any())
                throw new DomainException("O pedido deve conter ao menos um item.");


            Pedido pedido = new Pedido
            {
                IdPedido = pedidoDTO.IdPedido,
                ClienteId = pedidoDTO.ClienteId,
                ListaItensPedido = pedidoDTO.ListaItensPedido.Select(item => new PedidoItens
                {
                    IdPedido = item.IdItem,
                    IdProduto = item.ProdutoId,
                    Quantidade = item.Quantidade
                }).ToList()
            };
            _pedidoRepository.Incluir(pedido);
        }
        catch (DomainException ex)
        {
            throw new DomainException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao incluir o pedido: " + ex.Message);
        }
    }
    public List<PedidoDTO> Listar()
    {
        try 
        {
            if (!_pedidoRepository.Listar().Any())
                throw new DomainException("Nenhum pedido encontrado.");

            var pedidos = _pedidoRepository.Listar();
            return pedidos.Select(pedido => new PedidoDTO
            {
                IdPedido = pedido.IdPedido,
                ClienteId = pedido.ClienteId,
                ListaItensPedido = pedido.ListaItensPedido.Select(item => new PedidoItensDTO
                {
                    IdItem = item.IdPedido,
                    ProdutoId = item.IdProduto,
                    Quantidade = item.Quantidade
                }).ToList()
            }).ToList();
        }
        catch (DomainException)
        {
            throw new DomainException("Nenhum pedido encontrado.");
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar os pedidos: " + ex.Message);
        }
    }
    public void Remover(int id)
    {
        try
        {
            if (id <= 0)
                throw new DomainException("Id Indisponivel.");
            _pedidoRepository.Remover(id);

        }
        catch (DomainException)
        {
            throw new DomainException("Pedido não encontrado.");
        }

        catch (Exception ex)
        {
            throw new Exception("Erro ao remover o pedido: " + ex.Message);
        }
        
    }


}
