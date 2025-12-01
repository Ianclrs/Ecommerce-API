using Dapper;
using Domain.Entidades;
using Domain.Interfaces;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositorios;

public class ClienteRepository : IClienteRepository
{
    public void Cadastrar(Cliente cliente)
    {
        BancoSql.ListaClientes.Add(cliente);
    }

    public Cliente Logar(string Nome)
    {
        return BancoSql.ListaClientes.FirstOrDefault(c => c.Nome == Nome)!;
    }

    public Cliente ObterClientePorId(int id)
    {
        return BancoSql.ListaClientes.FirstOrDefault(c => c.Id == id)!;
    }

    public List<Cliente> Listar()
    {
        return BancoSql.ListaClientes.ToList();
    }

    public bool Remover(string Nome)
    {
        Cliente cliente = BancoSql.ListaClientes.FirstOrDefault(c => c.Nome == Nome.ToUpper());
        if (cliente != null)
        {
            BancoSql.ListaClientes.Remove(cliente);
            return true;
        }
        return false;
    }
    
}