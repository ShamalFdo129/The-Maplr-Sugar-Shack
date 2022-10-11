using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Moq;

using SugarShack.Application.Cart.Commands;
using SugarShack.Application.Cart.Queries;
using SugarShack.Application.Common.Exceptions;
using SugarShack.Application.Common.Mappings;
using SugarShack.Application.Product.Queries.GetAllProducts;
using SugarShack.Domain.Entities;
using SugarShack.Infrastructure;
using SugarShack.Infrastructure.Interceptors;


using Xunit;

namespace SugarShack.UnitTest.Application
{
    public class GetCartInfoHandlerTest
    {
        private readonly Mock<ApplicationDbContext> _context;
        private readonly IMapper _mapper;
        public GetCartInfoHandlerTest()
        {
            _context = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>(), new AuditableEntitySaveChangesInterceptor());

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public void Should_Return_CartInfo_When_Cart_IS_Available()
        {
            var mockedCart = MockingHelper.GetMockedDbSet(new List<Cart>() { new Cart {Id=1, Name = "Shamal's Cart", Items = new List<CartLineItem>()
                            { new CartLineItem() { Product = new Product() { Name = "Product1", Type = Domain.Enums.Catalogue.Dark, Price = 4.5 }, Quantity = 2 } } } });

            _context.Setup(m => m.Carts).Returns(mockedCart.Object);
            var query = new GetCartInfo();
            var handler = new GetCartInfoHandler(_context.Object, _mapper);
            var cart = handler.Handle(query, new CancellationToken());
            Assert.NotNull(cart);

        }

        [Fact]
        public void Should_Throw_Exception_When_No_CartInfo()
        {
            var mockedCart = MockingHelper.GetMockedDbSet(new List<Cart>() { });

            _context.Setup(m => m.Carts).Returns(mockedCart.Object);
            var query = new GetCartInfo();
            var handler = new GetCartInfoHandler(_context.Object, _mapper);
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query, new System.Threading.CancellationToken()));

        }

    }
}
