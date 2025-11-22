using Application;
using Application.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;



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

        return Ok(_clientesService.Listar());

    }
}
