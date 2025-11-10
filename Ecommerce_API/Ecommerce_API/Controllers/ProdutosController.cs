using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private ProdutosService _produtosService;

    public ProdutosController(ProdutosService produtosService)
    {
        _produtosService = produtosService;
    }

    [HttpPost]
    public ActionResult Incluir(ProdutoDTO produtoDTO)
    {

        _produtosService.Incluir(produtoDTO);

        return Ok();
    }

    [HttpGet]
    public ActionResult Listar()
    {
        return Ok(_produtosService.Listar());
    }
}
