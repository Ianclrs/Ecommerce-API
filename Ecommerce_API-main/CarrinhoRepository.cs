// Arquivo: Infrastructure/Repositorios/CarrinhoRepository.cs
using Domain.Interfaces;
using Domain.Entities;

public class CarrinhoRepository : ICarrinhoRepository
{
    public void Remover(int id)
    {
        var carrinho = BancoSql.ListaCarrinhos.FirstOrDefault(c => c.IdCarrinho == id);
        if (carrinho != null) BancoSql.ListaCarrinhos.Remove(carrinho);
    }

    public List<Carrinho> Listar()
    {
        return BancoSql.ListaCarrinhos.ToList();
    }

    public decimal CalcularTotal(int IdCarrinho)
    {
        var c = BancoSql.ListaCarrinhos.FirstOrDefault(x => x.IdCarrinho == IdCarrinho);
        return c?.CalcularTotal() ?? 0m;
    }
}