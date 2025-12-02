using Domain.Entidades;

namespace Application.DTOs;

public class ClienteDTO
{
    public string Nome { get; set; } = string.Empty;
    public Endereco EnderecoCliente { get; set; } = new();

    public Cliente Mapear()
    {
        Cliente cliente = new Cliente
        {
            Nome = this.Nome,
            EnderecoCliente = this.EnderecoCliente
        };
        return cliente;
    }
}

