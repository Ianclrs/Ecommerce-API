using Application.DTOs;
using Domain.Entidades;
using Domain.Helpers;
using Domain.Interfaces;
using Infrastructure.Data;


namespace Ecommerce_API.Services;

public class ClientesService
{
    private readonly IClienteRepository _clienteRepository;
    public ClientesService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    public void Cadastrar(Cliente cliente)
    {
        try
        {
            if (IsClienteInvalido(cliente))
                throw new DomainException("Dados do cliente não podem ser nulos.");
            else if (BancoSql.ListaClientes.Any(p => p.Id == cliente.Id))
                throw new ArgumentException("Esse ID ja esta cadastrado.");
            else if (BancoSql.ListaClientes.Any(p => p.Nome == cliente.Nome))
                throw new ArgumentException("Esse cliente ja esta cadastrado.");
            // Chamada ao repositório
            _clienteRepository.Cadastrar(cliente);
        }
        catch (DomainException ex)
        {
            throw new Exception("Erro ao cadastrar cliente: " + ex.Message);
        }
    }
    public List<ClienteDTO> Listar()
    {
        try
        {
            List<Cliente> clientes = _clienteRepository.Listar();
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
            foreach (Cliente cliente in clientes)
            {
 
                if (IsClienteInvalido(cliente))
                {
                    throw new DomainException("Cliente Invalido.");
                }

                ClienteDTO clienteDTO = new ClienteDTO
                {
                    Nome = cliente.Nome,
                    EnderecoCliente = cliente.EnderecoCliente,
                };
                clientesDTO.Add(clienteDTO);
                
            }
            return clientesDTO;
        }
        catch (DomainException ex)
        {
            throw new DomainException("Realmente não há o clientes: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException("Erro ao carregar o endereço do clientes: " + ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public ClienteDTO Logar(string Nome, string Senha)
    {
        try
        {
            Cliente cliente = new();
            if (BancoSql.ListaClientes.Any(p => p.Nome == Nome.ToUpper()) && BancoSql.ListaClientes.Any(p => p.Senha == Senha))
                cliente = _clienteRepository.Logar(Nome.ToUpper());
            else
            {
                throw new DomainException("Usuario ou Senha Ivalidos!");
            }
            ClienteDTO clienteDTO = new ClienteDTO
            {
                Nome = cliente.Nome,
                EnderecoCliente = cliente.EnderecoCliente
            };
            return clienteDTO;
        }
        catch (DomainException ex)
        {
            throw new DomainException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public ClienteDTO ObterClientePorId(int id)
    {
        try
        {// Buscar o cliente no repositório 
            Cliente cliente = _clienteRepository.ObterClientePorId(id);
            if (cliente == null)
            {
                throw new DomainException("Cliente não encontrado.");
            }
            ClienteDTO clienteDTO = new ClienteDTO
            {
                Nome = cliente.Nome,
                EnderecoCliente = cliente.EnderecoCliente
            };
            return clienteDTO;
        }

        catch (DomainException ex)
        {
            throw new DomainException("Cliente Inexistente: " + ex.Message);
        }
    }

    public void RemoverCliente(string Nome)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("Nome do cliente inválido.");
            bool removido = _clienteRepository.Remover(Nome);
            if (!removido)
                throw new DomainException("Cliente não encontrado para remoção.");
        }
        catch (DomainException ex)
        {
            throw new DomainException($"{ex.Message}");
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"{ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }

    private bool IsClienteInvalido(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome) || string.IsNullOrWhiteSpace(cliente.Senha) || cliente.Id == 0 || IsEnderecoInvalido(cliente.EnderecoCliente))
            return true;
        return false;
    }

    private bool IsEnderecoInvalido(Endereco endereco)
    {
        if (string.IsNullOrWhiteSpace(endereco.Cidade) || string.IsNullOrWhiteSpace(endereco.Estado))
            return true;
        return false;
    }
}
