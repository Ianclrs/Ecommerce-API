using Domain.Entidades;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositorios;

public class ClienteRepository : IClienteRepository
{
    public void Cadastrar(Cliente cliente)
    {
        BancoSql.ListaClientes.Add(cliente);
    }

    public List<Cliente> Listar()
    {
        return BancoSql.ListaClientes.ToList();
    }
}
