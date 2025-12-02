using Application.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Helpers;
using Domain.Entidades;

namespace Ecommerce_API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ClientesController : ControllerBase
{
    private ClientesService _clientesService;
    public ClientesController(ClientesService clientesService)
    {

        _clientesService = clientesService;
    }

    [HttpPost("Cadastrar")]
    public ActionResult Cadastrar([FromBody] Cliente cliente)
    {
        try
        {
            _clientesService.Cadastrar(cliente);
            return Ok("Cliente cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Logar/{Nome}/{Senha}")]
    public ActionResult Logar(string Nome, string Senha)
    {
        try
        {
            ClienteDTO cliente = _clientesService.Logar(Nome, Senha);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");
            return Ok("Login feito com sucesso!");
        }
        catch (DomainException ex)
        { //Erro precissível de domínio
            return BadRequest(ex.Message);
        }
        catch (Exception)
        { //Erro não precissível
            return StatusCode(500, "Erro interno do servidor.");
        }
    }

    [HttpGet("ListarClientes")]
    public ActionResult ListarClientes()
    {
        try
        {//Código que pode gerar exceções
            List<ClienteDTO> clientes = _clientesService.Listar();
            if (clientes == null || clientes.Count == 0)
                return NotFound("Nenhum cliente encontrado.");
            return Ok(clientes);

        }
        catch (DomainException ex)
        { //Erro precissível de domínio
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        { //Erro precissível de argumento inválido
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        { //Erro não precissível
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpGet("ObterCliente/{id:int}")]
    public ActionResult ObterClientePorId(int id)
    {
        try
        {
            ClienteDTO cliente = _clientesService.ObterClientePorId(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");
            return Ok(cliente);
        }
        catch (DomainException ex)
        { //Erro precissível de domínio
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        { //Erro precissível de argumento inválido
            return BadRequest(ex.Message);
        }
        catch (Exception)
        { //Erro não precissível
            return StatusCode(500, "Erro interno do servidor.");
        }
    }

    [HttpDelete("RemoverCliente/{Nome}")]
    public ActionResult RemoverCliente(string Nome)
    {
        try
        {// Verifica se o produto existe antes de tentar removê-lo
            _clientesService.RemoverCliente(Nome);
            return Ok("Cliente removido com sucesso.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (DomainException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao remover o produto: {ex.Message}");
        }
    }
}
