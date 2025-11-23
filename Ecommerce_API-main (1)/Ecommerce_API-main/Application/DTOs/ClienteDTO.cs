using Domain.Entidades;

namespace Application.DTOs;

public class ClienteDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;

    public Cliente Mapear()
    {
        return new Cliente
        {
            Id = this.Id,
            Nome = this.Nome,
            Endereco = this.Endereco
        };
    }
}
