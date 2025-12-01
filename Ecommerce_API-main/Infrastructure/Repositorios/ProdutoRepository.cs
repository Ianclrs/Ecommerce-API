using Domain.Entidades;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositorios;
public class ProdutoRepository : IProdutoRepository
{
    private readonly IProdutoRepositoryJson _produtoRepositoryJson;
    public ProdutoRepository(IProdutoRepositoryJson produtoRepositoryJson)
    {
        _produtoRepositoryJson = produtoRepositoryJson;
    }

    public void Incluir(Produto produto)
    {
        BancoSql.ListaProdutos.Add(produto);
    }

    public List<Produto> Listar()
    {
        BancoSql.ListaProdutos = _produtoRepositoryJson.ReceberDoArquivo();
        return BancoSql.ListaProdutos.ToList();
    }
    public bool Remover(int id)
    {
        Produto produto = BancoSql.ListaProdutos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            BancoSql.ListaProdutos.Remove(produto);
            return true;
        }
        return false;
    }
    public void AtualizarQuantidade(int produtoId, int quantidade)
    {
        Produto produto = BancoSql.ListaProdutos.FirstOrDefault(p => p.Id == produtoId);
        if (produto != null)
        {
            produto.Quantidade = quantidade;
        }
    }
    public Produto? ObterProdutoPorId(int id)
    {
        return BancoSql.ListaProdutos.FirstOrDefault(p => p.Id == id);
    }
}
