using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_API.Services;
using System;
using Domain.Helpers;
using Domain.Entidades;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private CarrinhoService _carrinhoService;
        public CarrinhoController(CarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }
        [HttpGet("Listar")]
        public ActionResult Listar()
        {
            try
            {// Chama o serviço para listar os carrinhos
                List<CarrinhoDTO> carrinhos = _carrinhoService.Listar();
                if (carrinhos == null || carrinhos.Count == 0)
                    return NotFound("Nenhum carrinho encontrado.");
                return Ok(carrinhos);
            }
            catch (DomainException ex)
            { //Erro precissível de domínio
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            { //Erro precissível de argumento inválido
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            { //Erro não precissível
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");

            }
        }
        [HttpDelete("Remover/{id}")]
        public ActionResult Remover(int id)
        {
            try
            {// Verifica se o carrinho existe antes de tentar removê-lo
                _carrinhoService.Remover(id);
                return Ok("Carrinho removido com sucesso.");
            }
            catch (DomainException ex)
            { //Erro precissível de domínio
                return BadRequest(ex.Message);
            }
            catch (Exception)
            { //Erro não precissível
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpGet("CalcularTotal/{idCarrinho:int}")]
        public ActionResult CalcularTotal(int idCarrinho)
        {
            try
            {
                decimal total = _carrinhoService.CalcularTotal(idCarrinho);
                return Ok($"Total: {total}");
            }
            catch (DomainException ex)
            { //Erro precissível de domínio
                return BadRequest(ex.Message);
            }
            catch (Exception)
            { //Erro não precissível
                return StatusCode(500, "Erro interno do servidor.");

            }
        }

        [HttpPost("AdicionarItem/{idCarrinho:int}")]
        public ActionResult AdicionarItem(int idCarrinho, [FromBody] ItemCarrinho itemCarrinho)
        {
            try
            {
                _carrinhoService.AdicionarItem(idCarrinho, itemCarrinho);
                return Ok("Item adicionado ao carrinho com sucesso.");
            }
            catch (DomainException ex)
            { //Erro precissível de domínio
                return BadRequest(ex.Message);
            }
            catch (Exception)
            { //Erro não precissível
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPost("AdicionarCarrinho")]
        public ActionResult AdicionarCarrinho([FromBody] Carrinho carrinho)
        {
            try
            {
                _carrinhoService.AdicionarCarrinho(carrinho);
                return Ok("Carrinho adicionado com sucesso.");
            }
            catch (DomainException ex)
            { //Erro precissível de domínio
                return BadRequest(ex.Message);
            }
            catch (Exception)
            { //Erro não precissível
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpGet("ListarItensCarrinho/{idCarrinho:int}")]
        public ActionResult ListarItensCarrinho(int idCarrinho)
        {
            try
            {
                List<ItemCarrinhoDTO> itensCarrinho = _carrinhoService.ListarItensCarrinho(idCarrinho);
                if (itensCarrinho == null || itensCarrinho.Count == 0)
                    return NotFound("Nenhum item encontrado no carrinho.");
                return Ok(itensCarrinho);
            }
            catch (DomainException ex)
            { //Erro precissível de domínio
                return BadRequest(ex.Message);
            }
            catch (Exception)
            { //Erro não precissível
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpDelete("RemoverItem/{idCarrinho:int}/{idItem:int}")]
        public ActionResult RemoverItem(int idCarrinho, int idItem)
        {
            try
            {
                _carrinhoService.RemoverItem(idCarrinho, idItem);
                return Ok("Item removido do carrinho com sucesso.");
            }
            catch (DomainException ex)
            { //Erro precissível de domínio
                return BadRequest(ex.Message);
            }
            catch (Exception)
            { //Erro não precissível
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpDelete("SubtrairQuantidade/{idCarrinho:int}/{idItem:int}/{quantidade:int}")]
        public ActionResult SubtrairQuantidadeItem(int idCarrinho, int idItem, int quantidade)
        {
            try
            {
                _carrinhoService.SubtrairQuantidadeItem(idCarrinho, idItem, quantidade);
                return Ok("Quantidade do item subtraída com sucesso.");
            }
            catch (DomainException ex)
            { //Erro precissível de domínio
                return BadRequest(ex.Message);
            }
            catch (Exception)
            { //Erro não precissível
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}
