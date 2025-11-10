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
}
