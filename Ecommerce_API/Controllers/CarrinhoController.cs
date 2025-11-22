using Application;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_API.Services;

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
        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(_carrinhoService.Listar());
        }
        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {             _carrinhoService.Remover(id);
            return Ok();
        }
        [HttpGet("total")]
        public ActionResult CalcularTotal()
        {
            decimal total = _carrinhoService.CalcularTotal();
            return Ok(total);
        }
    }
}
