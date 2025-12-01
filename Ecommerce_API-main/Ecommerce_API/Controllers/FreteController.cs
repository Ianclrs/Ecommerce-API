using Application;
using Application.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Helpers;

namespace Ecommerce_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FreteController : ControllerBase
{
    private readonly FreteService _freteService;
    public FreteController(FreteService freteService)
    {
        _freteService = freteService;
    }
    [HttpPost("Calculo")]
    public ActionResult CalcularFrete([FromBody] FreteDTO freteDTO)
    {
        try
        {
            decimal resultado = _freteService.CalcularFrete(freteDTO);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }

    }
}
