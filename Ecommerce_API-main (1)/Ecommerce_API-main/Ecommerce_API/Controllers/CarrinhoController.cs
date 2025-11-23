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
                var carrinhos = _carrinhoService.Listar();
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
            catch (Exception)
            { //Erro não precissível
                return StatusCode(500, "Erro interno do servidor.");

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
        [HttpGet("{id}/CalcularTotal")]
        public ActionResult CalcularTotal(int id)
        {
            try
            {
                var total = _carrinhoService.CalcularTotal(id);
                return Ok(new { IdCarrinho = id, Total = total });
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
