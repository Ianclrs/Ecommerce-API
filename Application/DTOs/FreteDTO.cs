using Domain.Entidades;


namespace Application.DTOs;


public class FreteDTO
{
    public string CepOrigem { get; set; } = string.Empty;

    public string CepDestino { get; set; } = string.Empty;
    public Cliente Mapear()
    {
        return new Cliente
        {
            Endereco = this.CepDestino

        };
    }
}
