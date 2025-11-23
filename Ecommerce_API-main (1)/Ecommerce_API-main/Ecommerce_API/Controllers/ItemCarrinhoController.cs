using Application;
using Application.DTOs;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCarrinhoController : ControllerBase
    {
        public ItemCarrinhoController()
        { 
        }
        [HttpGet("Imprimir SubTotal")]
        public ActionResult<decimal> ImprimirSubTotal(ItemCarrinhoDTO itemCarrinhoDTO)
        {// Retorna o subtotal do item do carrinho
            return Ok(itemCarrinhoDTO.SubTotal);
        }
    }
}
