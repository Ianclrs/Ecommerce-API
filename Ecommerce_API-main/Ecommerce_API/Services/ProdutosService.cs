using Application.DTOs;
using Domain.Entidades;
using Domain.Interfaces;
using Domain.Helpers;
using Infrastructure.Data;

namespace Ecommerce_API.Services;

public class ProdutosService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IProdutoRepositoryJson _produtoRepositoryJson;

    public ProdutosService(IProdutoRepository produtoRepository, IProdutoRepositoryJson produtoRepositoryJson)
    {
        _produtoRepository = produtoRepository;
        _produtoRepositoryJson = produtoRepositoryJson;
    }

    public void Incluir(Produto produto)
    {
        if (IsProdutoInvalido(produto))
            throw new ArgumentException("Todos os dados do produto devem ser devidamente preenchidos!!!");
        if (BancoSql.ListaProdutos.Any(p => p.Id == produto.Id) || BancoSql.ListaProdutos.Any(p => p.Nome == produto.Nome))
            throw new ArgumentException("Esse produto ja existe no catalogo");
        _produtoRepository.Incluir(produto);
        _produtoRepositoryJson.SalvarNoArquivo();
    }

    public List<Produto> Listar()
    {
        try
        {
            List<Produto> listaProdutos = _produtoRepository.Listar()
                ?? throw new DomainException("Nenhum produto foi encontrado.");
            if (listaProdutos.Count == 0)
                throw new DomainException("Nenhum produto disponível para listar.");
            return listaProdutos;
        }
        catch (DomainException ex)
        {
            // Erros de domínio são relançados
            throw new DomainException($"{ex.Message}");
        }
        catch (Exception ex)
        {
            // Qualquer erro inesperado é encapsulado
            throw new Exception($"{ex.Message}");
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
            else
                _produtoRepositoryJson.SalvarNoArquivo();
        }
        catch (DomainException ex)
        {
            throw new DomainException($"{ex.Message}");
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"{ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }


    public void AtualizarQuantidade(int produtoId, int quantidade)
    {
        try
        {
            if (produtoId <= 0)
                throw new ArgumentException("Id do produto inválido.");
            if (quantidade < 0)
                throw new ArgumentException("Quantidade não pode ser negativa.");
            Produto produto = _produtoRepository.Listar()
                .FirstOrDefault(p => p.Id == produtoId)
                ?? throw new DomainException("Produto não encontrado.");
            // regra de negócio: atualizar o estoque
            produto.Quantidade = quantidade;
            _produtoRepository.AtualizarQuantidade(produtoId, quantidade);
            _produtoRepositoryJson.SalvarNoArquivo();
        }
        catch (DomainException ex)
        {
            throw new DomainException($"{ex.Message}");
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"{ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }

    public ProdutoDTO ObterProdutoPorId(int id)
    {
        try
        {
            if (id <= 0)
                throw new ArgumentException("Id do produto inválido.");
            Produto? produto = _produtoRepository.ObterProdutoPorId(id);
            if (produto == null)
                throw new DomainException("Produto não encontrado.");
            ProdutoDTO produtoDTO = new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Quantidade = produto.Quantidade
            };
            return produtoDTO;
        }
        catch (DomainException ex)
        {
            throw new DomainException($"{ex.Message}");
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"{ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }
    private bool IsProdutoInvalido(Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome) || produto.Preco == 0 || produto.Id == 0 || produto.Quantidade == 0)
            return true;
        return false;
    }
}
