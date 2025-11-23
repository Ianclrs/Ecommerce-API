using Domain.Entidades;


namespace Application.DTOs;


public class FreteDTO
{
    public string EstadoOrigem { get; set; } = string.Empty;

    public string EstadoDestino { get; set; } = string.Empty;
    public List<Endereco> ListaDeEnderecos { get; set; } = new();
    public Cliente Mapear()
    {
        return new Cliente
        {
            Endereco = this.EstadoDestino,

        };
    }
}
