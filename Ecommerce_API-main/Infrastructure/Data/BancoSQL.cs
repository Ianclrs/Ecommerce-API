using Domain.Entidades;

namespace Infrastructure.Data;

public static class BancoSql
{
    public static List<Produto> ListaProdutos { get; set; } = new();
    public static List<Cliente> ListaClientes { get; set;} = new();
}
