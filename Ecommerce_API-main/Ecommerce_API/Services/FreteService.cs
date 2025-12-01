using Application.DTOs;
using Domain.Entidades;
using Domain.Interfaces;
using Ecommerce_API.Services;


namespace Ecommerce_API.Services;

public class FreteService
{
    private readonly IClienteRepository _clienteRepository;

    public FreteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public decimal CalcularFrete(FreteDTO dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        var cliente = _clienteRepository.ObterClientePorId(dto.ClienteId);

        if (cliente == null)
            throw new Exception("Cliente não encontrado.");

        var estado = cliente.EnderecoCliente.Estado;

        IFreteRepsitory frete = estado switch
        {
            "RJ" => new RJ(),
            "SP" => new SP(),
            "MG" => new MG(),
            _ => throw new Exception("Estado não atendido para frete.")
        };

        return frete.CalcularFrete(cliente);
    }
}

