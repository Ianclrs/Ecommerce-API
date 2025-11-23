using Application.DTOs;
using Domain.Entidades;
using Domain.Interfaces;
using Domain.Helpers;

namespace Ecommerce_API.Services;

public class ProdutosService
{
    private IProdutoRepository _produtoRepository;

    public ProdutosService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public void Incluir(ProdutoDTO produtoDTO)
    {
        try
        {
            if (produtoDTO == null)
                throw new ArgumentException("Os dados do produto não podem ser nulos.");
            Produto produto = produtoDTO.Mapear();
            if (produto == null)
                throw new ArgumentException("Falha ao mapear os dados do produto.");
            _produtoRepository.Incluir(produto);

        }
        catch (DomainException)
        {
            // Repassa a exceção de domínio para o controller tratar
            throw;

        }
        catch (ArgumentException)
        {
            // Repassa a exceção de argumento para o controller tratar
            throw;
        }
        catch (Exception ex)
        {
            // Qualquer erro inesperado é encapsulado
            throw new Exception("Erro ao incluir o produto.", ex);
        }
    }


    public List<ProdutoDTO> Listar()
    {
        try
        {
            var listaProdutos = _produtoRepository.Listar()
                ?? throw new DomainException("Nenhum produto foi encontrado.");
            if (listaProdutos.Count == 0)
                throw new DomainException("Nenhum produto disponível para listar.");
            List<ProdutoDTO> listaProdutosDTO = new List<ProdutoDTO>();
            foreach (var produto in listaProdutos)
            {
                if (produto == null)
                    throw new DomainException("Produto inválido encontrado na coleção.");
                // Mapear Produto para ProdutoDTO
                listaProdutosDTO.Add(new ProdutoDTO
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                });
            }
            return listaProdutosDTO;
        }
        catch (DomainException)
        {
            // Repassa a exceção de domínio para o controller tratar
            throw;
        }
        catch (Exception ex)
        {
            // Qualquer erro inesperado é encapsulado
            throw new Exception("Erro ao listar produtos.", ex);
        }
    }
    public void Remover(int id)
    {
        try
        {
            if (id <= 0)
                throw new ArgumentException("Id do produto inválido.");
            bool removido = _produtoRepository.Remover(id);
            if (!removido)
                throw new DomainException("Produto não encontrado para remoção.");
        }
        catch (DomainException)
        {
            throw; 
        }
        catch (ArgumentException)
        {
            throw; 
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao remover o produto.", ex);
        }
    }
    public void AtualizarEstoque(int produtoId, int quantidade)
    {
        try
        {
            if (produtoId <= 0)
                throw new ArgumentException("Id do produto inválido.");
            if (quantidade < 0)
                throw new ArgumentException("Quantidade não pode ser negativa.");
            var produto = _produtoRepository.Listar()
                .FirstOrDefault(p => p.Id == produtoId)
                ?? throw new DomainException("Produto não encontrado.");
            // regra de negócio: atualizar o estoque
            produto.Quantidade = quantidade;
            _produtoRepository.AtualizarEstoque(produtoId, quantidade);
        }
        catch (DomainException)
        {
            throw; 
        }
        catch (ArgumentException)
        {
            throw; 
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar o estoque do produto.", ex);
        }
    }
}
