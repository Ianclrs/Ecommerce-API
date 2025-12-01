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
        private readonly ItemCarrinhoService _itemCarrinhoService;
        public ItemCarrinhoController(ItemCarrinhoService service)
        {
            _itemCarrinhoService = service;
        }
        [HttpPost("subtotal")]
        public ActionResult ObterSubTotal([FromBody] ItemCarrinhoDTO dto)
        {
            try
            {
                decimal subtotal = _itemCarrinhoService.ObterSubTotal(dto);
                return Ok(subtotal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
