using Application.DTOs;
using Domain.Entidades;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Helpers;


namespace Ecommerce_API.Services
{
    public class CarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        public CarrinhoService(ICarrinhoRepository carrinhoRepository, IProdutoRepository produtoRepository, IClienteRepository clienteRepository)
        {
            _carrinhoRepository = carrinhoRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
        }

        public void AdicionarCarrinho(Carrinho carrinho)
        {
            try
            {
                if (carrinho == null)
                    throw new DomainException("Carrinho não pode ser nulo.");
                Cliente? cliente = _clienteRepository.ObterClientePorId(carrinho.ClienteId);
                if (cliente.Id == 0 || cliente == null)
                    throw new DomainException("ID do cliente inválido.");
                _carrinhoRepository.AdicionarCarrinho(carrinho);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar o carrinho.", ex);
            }
        }
        public void AdicionarItem(int idCarrinho, ItemCarrinho item)
        {
            try
            {
                if (item == null)
                    throw new DomainException("Item não pode ser nulo.");
                if (item.Quantidade <= 0)
                    throw new DomainException("Quantidade do item deve ser maior que zero.");
                Produto produto = _produtoRepository.ObterProdutoPorId(item.IdProduto)!;
                if (produto == null)
                    throw new ArgumentException("Produto Inexistente");
                item.Preco = produto.Preco;
                item.SubTotal = item.Preco * item.Quantidade;
                _carrinhoRepository.AdicionarItem(idCarrinho, item);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Erro ao adicionar item: { ex.Message }");
            }
            catch (DomainException ex)
            {
                throw new DomainException($"Erro ao adicionar item ao carrinho: { ex.Message }");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar item ao carrinho.", ex);
            }
        }

        public List<CarrinhoDTO> Listar()
        {
            try
            {
                List<Carrinho> listaCarrinhos = _carrinhoRepository.Listar()
                    ?? throw new DomainException("Nenhum carrinho foi encontrado.");

                if (listaCarrinhos.Count == 0)
                    throw new DomainException("Nenhum carrinho disponível para listar.");

                List<CarrinhoDTO> listaCarrinhosDTO = new List<CarrinhoDTO>();

                foreach (Carrinho carrinho in listaCarrinhos)
                {
                    if (carrinho == null)
                        // Validação adicional para carrinho nulo
                        throw new DomainException("Carrinho inválido encontrado na coleção.");

                    CarrinhoDTO dto = new CarrinhoDTO
                    {
                        ClienteId = carrinho.ClienteId,
                        ListaItensCarrinho = carrinho.ListaItensCarrinho?.Select(item =>
                        {
                            if (item == null)
                                throw new DomainException("Item de carrinho inválido.");

                            if (item.Quantidade <= 0)
                                throw new DomainException($"Item com quantidade inválida (IdProduto: {item.IdProduto}).");

                            return new ItemCarrinhoDTO
                            {
                                IdProduto = item.IdProduto,
                                Quantidade = item.Quantidade,
                                Preco = item.Preco,
                                SubTotal = item.SubTotal
                            };
                        }).ToList() ?? new List<ItemCarrinhoDTO>(),
                        Total = CalcularTotal(carrinho.IdCarrinho)
                    };

                    listaCarrinhosDTO.Add(dto);
                }

                return listaCarrinhosDTO;
            }
            catch (Exception ex)
            {
                // Qualquer erro inesperado é encapsulado
                throw new Exception("Erro ao listar carrinhos.", ex);
            }
        }
        public void Remover(int id)
        {
            try
            {
                if (id < 0)
                    throw new DomainException("ID do carrinho inválido.");
                _carrinhoRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o carrinho.", ex);
            }
        }
        public decimal CalcularTotal(int idCarrinho)
        {
            try
            {
                Carrinho carrinho = _carrinhoRepository.Listar()
                    .FirstOrDefault(c => c.IdCarrinho == idCarrinho)
                    ?? throw new DomainException("Carrinho não encontrado para calcular o total.");
                if (carrinho.ListaItensCarrinho == null || carrinho.ListaItensCarrinho.Count == 0)
                    throw new DomainException("O carrinho está vazio. Não é possível calcular o total.");
                carrinho.Total = carrinho.ListaItensCarrinho.Sum(i => i.SubTotal);
                return carrinho.Total;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao calcular o total do carrinho.", ex);
            }
        }

        public List<ItemCarrinhoDTO> ListarItensCarrinho(int idCarrinho)
        {
            try
            {
                Carrinho carrinho = _carrinhoRepository.Listar()
                    .FirstOrDefault(c => c.IdCarrinho == idCarrinho)
                    ?? throw new DomainException("Carrinho não encontrado.");
                if (carrinho.ListaItensCarrinho == null || carrinho.ListaItensCarrinho.Count == 0)
                    throw new DomainException("O carrinho está vazio.");
                List<ItemCarrinhoDTO> listaItensCarrinhoDTO = new();
                foreach (ItemCarrinho i in carrinho.ListaItensCarrinho)
                {
                    ItemCarrinhoDTO itemDTO = new ItemCarrinhoDTO
                    {
                        IdProduto = i.IdProduto,
                        Quantidade = i.Quantidade,
                        Preco = i.Preco,
                        SubTotal = i.SubTotal
                    };
                    listaItensCarrinhoDTO.Add(itemDTO);
                }
                return listaItensCarrinhoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os itens do carrinho.", ex);
            }
        }

        public void RemoverItem(int idCarrinho, int idItem)
        {
            try
            {
                if (idCarrinho < 0)
                    throw new DomainException("ID do carrinho inválido.");
                if (idItem < 0)
                    throw new DomainException("ID do produto inválido.");
                _carrinhoRepository.RemoverItem(idCarrinho, idItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover o item do carrinho.", ex);
            }
        }

        public void SubtrairQuantidadeItem(int idCarrinho, int idItem, int decrescimo)
        {
            try
            {
                if (idCarrinho < 0)
                    throw new DomainException("ID do carrinho inválido.");
                if (idItem < 0)
                    throw new DomainException("ID do produto inválido.");
                if (decrescimo <= 0)
                    throw new DomainException("O decrescimo deve ser maior que zero.");
                _carrinhoRepository.SubtrairQuantidadeItem(idCarrinho, idItem, decrescimo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao subtrair a quantidade do item no carrinho.", ex);
            }
        }
    }
}
