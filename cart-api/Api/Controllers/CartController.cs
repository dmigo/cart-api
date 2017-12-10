using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Cart;
using Api.Mappers;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        ICartFacade _cartFacade;

        public CartController(ICartFacade cartFacade)
        {
            _cartFacade = cartFacade;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cart = _cartFacade.GetCurrentCart();
            var result = cart.ToModel();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody]CartModel cartModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var cart = cartModel.ToDomain();
            _cartFacade.UpdateCart(cart);
            return Ok();
        }
    }
}
