using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Moq;

using SugarShack.Application.Cart.Commands;
using SugarShack.Application.Common.Exceptions;
using SugarShack.Application.Common.Mappings;
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
    public class AddItemToCartHandlerTest
    {

        private readonly Mock<ApplicationDbContext> _context;
        public AddItemToCartHandlerTest()
        {
            _context = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>(), new AuditableEntitySaveChangesInterceptor());

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
        }

        [Fact]
        public void Should_Throw_Exception_When_product_IS_Invalid()
        {
            var cmd = new AddItemToCart() { ProductId = 10, Quantity = 2 };
            var handler = new AddItemToCartHandler(_context.Object);
            _context.Setup(m => m.SaveChanges()).Returns(1);
            var mockedProduct = MockingHelper.GetMockedDbSet(new List<Product> {
                new Product {  Id = 1,Type = Domain.Enums.Catalogue.Dark, Price=3.5},

            });

            var mockedCart = MockingHelper.GetMockedDbSet(new List<Cart> { });

            _context.Setup(m => m.Products).Returns(mockedProduct.Object);
            _context.Setup(m => m.Carts).Returns(mockedCart.Object);
            Assert.ThrowsAsync<ValidationException>(() => handler.Handle(cmd, new System.Threading.CancellationToken()));

        }

        [Fact]
        public void Should_Throw_Exception_When_Quantity_IS_Invalid()
        {
            var cmd = new AddItemToCart() { ProductId = 1, Quantity = 0 };
            var handler = new AddItemToCartHandler(_context.Object);
            _context.Setup(m => m.SaveChanges()).Returns(1);
            var mockedProduct = MockingHelper.GetMockedDbSet(new List<Product> {
                new Product {  Id = 1,Type = Domain.Enums.Catalogue.Dark, Price=3.5},

            });

            var mockedCart = MockingHelper.GetMockedDbSet(new List<Cart> { });

            _context.Setup(m => m.Products).Returns(mockedProduct.Object);
            _context.Setup(m => m.Carts).Returns(mockedCart.Object);
            Assert.ThrowsAsync<ValidationException>(() => handler.Handle(cmd, new System.Threading.CancellationToken()));

        }


        [Fact]
        public void Should_Return_True_When_Item_Added_Successfully()
        {
            var cmd = new AddItemToCart() { ProductId = 1, Quantity = 10 };
            var handler = new AddItemToCartHandler(_context.Object);
            _context.Setup(m => m.SaveChanges()).Returns(1);
            var mockedProduct = MockingHelper.GetMockedDbSet(new List<Product> {
                new Product {  Id = 1,Type = Domain.Enums.Catalogue.Dark, Price=3.5},

            });

            var mockedCart = MockingHelper.GetMockedDbSet(new List<Cart> { });

            _context.Setup(m => m.Products).Returns(mockedProduct.Object);
            _context.Setup(m => m.Carts).Returns(mockedCart.Object);
            var result = handler.Handle(cmd, new System.Threading.CancellationToken());
            Assert.True(result.Result);

        }

    }
}
