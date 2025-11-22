using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_API.Services;

namespace Ecommerce_API.Controllers;
[Route("api/[controller]")]
[ApiController]

public class PedidosController : ControllerBase
{
    private PedidosService _pedidosService;
    public PedidosController(PedidosService pedidosService)
    {
        _pedidosService = pedidosService;
    }
    [HttpPost]
    public ActionResult Incluir(PedidoDTO pedidoDTO)
    {
        _pedidosService.Incluir(pedidoDTO);
        return Ok();
    }
    [HttpGet]
    public ActionResult Listar()
    {
        return Ok(_pedidosService.Listar());
    }
    [HttpDelete("{id}")]
    public ActionResult Remover(int id)
    {
        _pedidosService.Remover(id);
        return Ok();
    }
}
