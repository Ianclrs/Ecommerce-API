using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_API.Services;
using Domain.Helpers;

namespace Ecommerce_API.Controllers;
[Route("api/[controller]")]
[ApiController]

public class PedidosController : ControllerBase
{// Injeção de dependência do serviço de pedidos
    private PedidosService _pedidosService;
    public PedidosController(PedidosService pedidosService)
    {
        _pedidosService = pedidosService;
    }
    [HttpPost("incluir")]
    public ActionResult Incluir(PedidoDTO pedidoDTO)
    {
        try
        {// Chama o serviço para incluir o pedido
            _pedidosService.Incluir(pedidoDTO);
            return Ok("O pedido foi incluido com sucesso.");

        }
        catch(DomainException ex)
        {// Tratamento de exceções específicas
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {// Tratamento de exceções genéricas
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public ActionResult Listar()
    {
        try
        {// Chama o serviço para listar os pedidos
            var listaPedidos = _pedidosService.Listar();
            return Ok(listaPedidos);

        }
        catch (DomainException ex)
        {
            return NotFound(ex.Message);
        }// Tratamento de exceções genéricas
        catch (Exception)
        {
            return StatusCode(500, "Erro interno do servidor.");
        }
    }
    [HttpDelete("{id}")]
    public ActionResult Remover(int id)
    {
        try
        {// Verifica se o pedido existe antes de tentar removê-lo
            _pedidosService.Remover(id);
            return Ok("O pedido foi removido com sucesso.");

        }// Tratamento de exceções específicas
        catch (DomainException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {// Tratamento de exceções genéricas
            return StatusCode(500, "Erro interno do servidor: " + ex.Message);
        }
    }
}
