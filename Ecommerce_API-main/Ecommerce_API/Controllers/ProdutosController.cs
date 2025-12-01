using Application.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Helpers;
using Domain.Entidades;

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

    [HttpPost("Incluir")]
    public ActionResult Incluir([FromBody] Produto produto)
    {
        try
        {// Chama o serviço para incluir o produto
            _produtosService.Incluir(produto);
            return Ok("Produto incluído com sucesso.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Erro ao incluir o produto: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao incluir o produto: {ex.Message}");
        }
    }

    [HttpGet("Listar")]
    public ActionResult Listar()
    {
        try
        {// Chama o serviço para listar os produtos
            List<Produto> produtos = _produtosService.Listar();
            if (produtos == null || produtos.Count == 0)
                return NotFound("Nenhum produto encontrado.");
            return Ok(produtos);
        }
        catch (DomainException ex)
        {
            return NotFound(ex.Message); // Erro precissível de domínio
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}"); // Erro não precissível
        }
    }

    [HttpDelete("Remover/{id:int}")]
    public ActionResult Remover(int id)
    {
        try
        {// Verifica se o produto existe antes de tentar removê-lo
            _produtosService.Remover(id);
            return Ok("Produto removido com sucesso.");
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

    [HttpPut("AtualizarQuantidade/{produtoId:int}/{quantidade:int}")]

    public ActionResult AtualizarQuantidade(int produtoId, int quantidade)
    {
        try
        {// Chama o serviço para atualizar o estoque do produto
            _produtosService.AtualizarQuantidade(produtoId, quantidade);
            return Ok("Estoque atualizado com sucesso.");
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
            return StatusCode(500, $"Erro ao atualizar o estoque: {ex.Message}");
        }
    }

    [HttpGet("ObterProdutoPorId/{id:int}")]
    public ActionResult<ProdutoDTO> ObterProdutoPorId(int id)
    {
        try
        {
            ProdutoDTO produtoDTO = _produtosService.ObterProdutoPorId(id);
            return Ok(produtoDTO);
        }
        catch (DomainException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao obter o produto: {ex.Message}");
        }
    }
}
