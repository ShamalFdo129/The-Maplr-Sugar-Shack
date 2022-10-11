using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Moq;

using SugarShack.Application.Common.Mappings;
using SugarShack.Application.Order.Commands;
using SugarShack.Domain.Entities;
using SugarShack.Infrastructure;
using SugarShack.Infrastructure.Interceptors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace SugarShack.UnitTest.Application
{
    public class PlaceOrderHandlerTest
    {
        private readonly Mock<ApplicationDbContext> _context;
        public PlaceOrderHandlerTest()
        {
            _context = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>(), new AuditableEntitySaveChangesInterceptor());

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
        }

        [Fact]
        public void Should_Return_True_When_Order_Processed_Successfully()
        {
            var mockedCart = MockingHelper.GetMockedDbSet(new List<Cart>() { new Cart {Id=1, Name = "Shamal's Cart", Items = new List<CartLineItem>()
                            { new CartLineItem() { Product = new Product() { Name = "Product1", Type = Domain.Enums.Catalogue.Dark, Price = 4.5 }, Quantity = 2 } } } });

            var mockedOrder = MockingHelper.GetMockedDbSet(new List<Order> { });
            _context.Setup(m => m.Carts).Returns(mockedCart.Object);
            _context.Setup(m => m.Orders).Returns(mockedOrder.Object);
            var cmd = new PlaceOrder() { CardId = 1 };
            var handler = new PlaceOrderHandler(_context.Object);
            var result = handler.Handle(cmd, new CancellationToken());
            Assert.True(result.Result);
        }

        [Fact]
        public void Should_Return_False_When_Order_Processed_Not_Successfully()
        {
            var mockedCart = MockingHelper.GetMockedDbSet(new List<Cart>() { });
            _context.Setup(m => m.Carts).Returns(mockedCart.Object);
            var cmd = new PlaceOrder() { CardId = 1 };
            var handler = new PlaceOrderHandler(_context.Object);
            var result = handler.Handle(cmd, new CancellationToken());
            Assert.False(result.Result);
        }
    }
}
