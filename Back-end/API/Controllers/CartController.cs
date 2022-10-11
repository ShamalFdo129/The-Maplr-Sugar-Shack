using Microsoft.AspNetCore.Mvc;

using SugarShack.Application.Cart.Commands;
using SugarShack.Application.Cart.Queries;
using SugarShack.Application.Cart.Queries.Dtos;

namespace The_Maplr_Sugar_Shack.Controllers
{
    public class CartController:  ApiControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public CartController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet, Route("GetCart")]
        public async Task<CartDto> GetCartInfo()
        {
            return await Mediator.Send(new GetCartInfo());
        }

        [HttpPost, Route("AddToCart")]
        public async Task<bool> AddToCart(AddItemToCart cmd)
        {
            return await Mediator.Send(cmd);
        }

        [HttpDelete, Route("RemoveFromCart")]
        public async Task<bool> RemoveFromCart(RemoveFromCart cmd)
        {
            return await Mediator.Send(cmd);
        }

        [HttpPatch, Route("ChangeQuantity")]
        public async Task<bool> ChangeQuantity(ChangeQuantity cmd)
        {
            return await Mediator.Send(cmd);
        }
    }
}
