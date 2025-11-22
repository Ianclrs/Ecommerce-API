using Domain.Entidades;

namespace Domain.Interfaces;

public interface IClienteRepository
{
    void Cadastrar(Cliente cliente);
    List<Cliente> Listar();
}
