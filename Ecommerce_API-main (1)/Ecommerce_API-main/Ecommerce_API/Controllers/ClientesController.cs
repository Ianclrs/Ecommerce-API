using Application;
using Application.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Helpers;



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

    [HttpPost]
    public ActionResult Cadastrar(ClienteDTO clienteDTO)
    {

        _clientesService.Cadastrar(clienteDTO);

        return Ok();

    }
    [HttpGet]
    public ActionResult Listar()
    {
        try
        {//Código que pode gerar exceções
            var clientes = _clientesService.Listar();
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
        catch (Exception)
        { //Erro não precissível
            return StatusCode(500, "Erro interno do servidor.");
        }



    }
    [HttpGet("{id}")]
    public ActionResult ObterClientePorId(int id)
    {
        try
        {
            var cliente = _clientesService.ObterClientePorId(id);
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
}
