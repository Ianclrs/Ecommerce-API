using Application.DTOs;
using Domain.Entidades;
using Domain.Helpers;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce_API.Services;

public class ClientesService
{
    private IClienteRepository _clienteRepository;
    public ClientesService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    public void Cadastrar(ClienteDTO clienteDTO)
    {
        Cliente cliente = clienteDTO.Mapear();
        _clienteRepository.Cadastrar(cliente);
    }
    public List<ClienteDTO> Listar()
    {
        try
        {
            var clientes = _clienteRepository.Listar();
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
            foreach (var cliente in clientes)
            {
 
                if (cliente == null)
                {
                    throw new DomainException("Cliente não encontrado.");
                }
                if (cliente.Endereco == null)
                {
                    throw new ArgumentException("Endereço do cliente não encontrado.");
                }

                ClienteDTO clienteDTO = new ClienteDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Endereco = cliente.Endereco
                };
                clientesDTO.Add(clienteDTO);
                
            }
            return clientesDTO;
        }
        catch (DomainException)
        {
            throw;
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar clientes: " + ex.Message);
        }
    }
    public ClienteDTO ObterClientePorId(int id)
    {
        try
        {// Buscar o cliente no repositório 
            var cliente = _clienteRepository.ObterClientePorId(id);
            if (cliente == null)
            {
                throw new DomainException("Cliente não encontrado.");
            }
            ClienteDTO clienteDTO = new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Endereco = cliente.Endereco
            };
            return clienteDTO;
        }
        catch (DomainException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao obter cliente: " + ex.Message);
        }
    }
}
