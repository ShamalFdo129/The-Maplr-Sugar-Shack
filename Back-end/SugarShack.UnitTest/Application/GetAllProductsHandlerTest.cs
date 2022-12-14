using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using SugarShack.Application.Cart.Commands;
using SugarShack.Application.Common.Exceptions;
using SugarShack.Application.Common.Mappings;
using SugarShack.Application.Product.Queries.GetAllProducts;
using SugarShack.Domain.Entities;
using SugarShack.Infrastructure;
using SugarShack.Infrastructure.Interceptors;


using Xunit;

namespace SugarShack.UnitTest.Application
{
    public class GetAllProductsHandlerTest
    {
        private readonly Mock<ApplicationDbContext> _context;
        private readonly IMapper _mapper;
        public GetAllProductsHandlerTest()
        {
            _context = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>(), new AuditableEntitySaveChangesInterceptor());

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public void Should_Return_productList_When_productList_IS_Available()
        {
       
            var mockedProduct = MockingHelper.GetMockedDbSet(new List<Product> {
                new Product {  Name = "Product1",Type = Domain.Enums.Catalogue.Dark, Price=3.5},
                 new Product {  Name = "Product2",Type = Domain.Enums.Catalogue.Dark, Price=3.5},
                  new Product {  Name = "Product3",Type = Domain.Enums.Catalogue.Dark, Price=3.5}
            });
            _context.Setup(m => m.Products).Returns(mockedProduct.Object);
            var query = new GetAllProducts();
            var handler = new GetAllProductsQueryHandler(_context.Object, _mapper);
            var products = handler.Handle(query, new CancellationToken());
            Assert.NotNull(products);

        }

        [Fact]
        public void Should_Throw_Exception_When_productList_IS_Empty()
        {
            var mockedProduct = MockingHelper.GetMockedDbSet(new List<Product> { });
            _context.Setup(m => m.Products).Returns(mockedProduct.Object);
            var query = new GetAllProducts();
            var handler = new GetAllProductsQueryHandler(_context.Object, _mapper);
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query, new System.Threading.CancellationToken()));

        }
       
    }
}
