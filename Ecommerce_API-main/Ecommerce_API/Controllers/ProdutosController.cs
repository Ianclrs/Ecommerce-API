using Application.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Domain.Helpers;

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

    [HttpPost("incluir")]
    public ActionResult Incluir([FromBody] ProdutoDTO produtoDTO)
    {
        try
        {// Chama o serviço para incluir o produto
            _produtosService.Incluir(produtoDTO);
            return Ok("Produto incluído com sucesso.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (DomainException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao incluir o produto: {ex.Message}");
        }
    }

    [HttpGet("listar")]
    public ActionResult Listar()
    {
        try
        {// Chama o serviço para listar os produtos
            var produtos = _produtosService.Listar();
            if (produtos == null || produtos.Count == 0)
                return NotFound("Nenhum produto encontrado.");
            return Ok(produtos);
        }
        catch (DomainException ex)
        {
            return NotFound(ex.Message); // Erro precissível de domínio
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro interno do servidor."); // Erro não precissível
        }
    }
    [HttpDelete("remover/{id:int}")]

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
    [HttpPut("AtualizarEstoque/{produtoId:int}/{quantidade:int}")]
    public ActionResult AtualizarEstoque(int produtoId, [FromQuery] int quantidade)
    {
        try
        {// Chama o serviço para atualizar o estoque do produto
            _produtosService.AtualizarEstoque(produtoId, quantidade);
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
}
