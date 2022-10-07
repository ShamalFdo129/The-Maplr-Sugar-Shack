using Microsoft.AspNetCore.Mvc;

using SugarShack.Application.Product.Queries.GetAllProducts;

namespace The_Maplr_Sugar_Shack.Controllers
{
 
    public class ProductController : ApiControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IList<ProductDto>> Get()
        {
             return await Mediator.Send(new GetAllProductsQuery());
        }

        //[HttpGet(Name = "GetAllproducts")]
        //public IEnumerable<WeatherForecast> GetAllproducts()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}