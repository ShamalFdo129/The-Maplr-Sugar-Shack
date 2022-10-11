using Microsoft.AspNetCore.Mvc;

using SugarShack.Application.Order.Commands;

namespace The_Maplr_Sugar_Shack.Controllers
{
    public class OrderController : ApiControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public OrderController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost, Route("PlaceOrder")]
        public async Task<bool> PlaceOrder(PlaceOrder cmd)
        {
            return await Mediator.Send(cmd);
        }
    }
}
