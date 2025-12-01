using Application.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;
public class PagamentoController : ControllerBase
{
}
//{
//    private readonly PagamentoService _pagamentoService;

//    public PagamentoController(PagamentoService pagamentoService)
//    {
//        _pagamentoService = pagamentoService;
//    }

//    [HttpPost]
//    public IActionResult Pagar([FromBody] PagamentoDTO dto)
//    {
//        try
//        {
//            var resultado = _pagamentoService.RealizarPagamento(dto);
//            return Ok(resultado);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { erro = ex.Message });
//        }
//    }

//    [HttpGet("{pedidoId}")]
//    public IActionResult BuscarResumo(int pedidoId)
//    {
//        var resumo = _pagamentoService.ObterResumoPorPedidoId(pedidoId);
//        if (resumo == null)
//            return NotFound();

//        return Ok(resumo);
//    }
//}
/*namespace Ecommerce_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PagamentosController : ControllerBase
{
    private PagamentoService _pagamentoService;

    public PagamentosController(PagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    //[HttpPost("Pagar")]
    //[HttpGet("ListarParcelas")]
}
*/