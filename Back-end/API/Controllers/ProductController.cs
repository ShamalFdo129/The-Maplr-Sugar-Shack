using Microsoft.AspNetCore.Mvc;

using SugarShack.Application.Common.Dtos;
using SugarShack.Application.Product.Queries;
using SugarShack.Application.Product.Queries.GetAllProducts;
using SugarShack.Application.Product.Queries.GetAllProductsByCatalogue;
using SugarShack.Domain.Enums;

namespace The_Maplr_Sugar_Shack.Controllers
{

    public class ProductController : ApiControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet, Route("GetProductInfo")]
        public async Task<IList<ProductDto>> GetAllproducts()
        {
            return await Mediator.Send(new GetAllProducts());
        }

        [HttpGet, Route("GetProductByCatalogue")]
        public async Task<IList<ProductDto>> GetAllProductsByCatalogue(Catalogue type)
        {
            return await Mediator.Send(new GetAllProductsByCatalogue() { Type = type });
        }


    }
}