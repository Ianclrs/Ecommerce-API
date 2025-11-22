using Application.DTOs;
using Ecommerce_API.Services;
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
    [HttpDelete("{id}")]

    public ActionResult Remover(int id) 
    {
        _produtosService.Remover(id);
        return Ok();
    }
    [HttpPut("AtualizarEstoque/{produtoId:int}/{quantidade:int}")]
    public ActionResult AtualizarEstoque(int produtoId, int quantidade)
    {
        if (produtoId <= 0 || quantidade < 0)
            return BadRequest("Id do Produto não foi encontrado ou quantidade negativa.");
        try
        {
            // O método AtualizarEstoque retorna void, então não atribua o resultado a uma variável.
            _produtosService.AtualizarEstoque(produtoId, quantidade);
            return Ok("Estoque atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao atualizar o estoque: {ex.Message}");
        }
    }
}
