using Domain.Entidades;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositorios;
public class ProdutoRepository : IProdutoRepository
{
    public void Incluir(Produto produto)
    {
        BancoSql.ListaProdutos.Add(produto);
    }

    public List<Produto> Listar()
    {
        return BancoSql.ListaProdutos.ToList();
    }
    public bool Remover(int id)
    {
        var produto = BancoSql.ListaProdutos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            BancoSql.ListaProdutos.Remove(produto);
        }
        return true;
    }
    public void AtualizarEstoque(int produtoId, int quantidade)
    {
        var produto = BancoSql.ListaProdutos.FirstOrDefault(p => p.Id == produtoId);
        if (produto != null)
        {
            produto.Quantidade = quantidade;
        }
    }
}
