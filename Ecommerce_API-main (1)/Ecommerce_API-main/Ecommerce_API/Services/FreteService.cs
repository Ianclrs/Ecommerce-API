using Application.DTOs;
using Domain.Entidades;
using Domain.Interfaces;
using Ecommerce_API.Services;


namespace Ecommerce_API.Services;

public class FreteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IFrete _freteService;
    public FreteService(IClienteRepository clienteRepository, IFrete freteService)
    {
        _clienteRepository = clienteRepository;
        _freteService = freteService;
    }

    public decimal Calcular(FreteDTO freteDTO)
    {
        try
        {// Validar o DTO de entrada
            if (freteDTO.ListaDeEnderecos == null || freteDTO.ListaDeEnderecos.Count == 0)
            {
                throw new ArgumentException("Lista de endereços inválida.");
            }
            // Supondo que o estado de destino está em freteDTO.EstadoDestino
            if (freteDTO.EstadoDestino != "RJ" && freteDTO.EstadoDestino != "SP" && freteDTO.EstadoDestino != "MG")
            {
                throw new ArgumentException("Estado de destino inválido.");
            }
        }
        catch (Exception)
        {
            throw;
        }
        
        // Mapear o DTO para a entidade Cliente
        Cliente cliente = freteDTO.Mapear();
        try
        {
            if (cliente == null || cliente.Id <= 0)
            {
                throw new ArgumentException("Cliente inválido.");
            }
            // Buscar o cliente no repositório
            cliente = _clienteRepository.ObterClientePorId(cliente.Id);

        }
        catch (Exception)
        {
            throw;
        }

        // Calcular o frete usando o serviço de frete injetado
        decimal valorFrete = _freteService.CalcularFrete(cliente);
        return valorFrete;
    }
    
}
