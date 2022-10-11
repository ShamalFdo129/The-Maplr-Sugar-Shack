using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using SugarShack.Application.Common.Interfaces;
using SugarShack.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Cart.Commands
{
    public record AddItemToCart: IRequest<bool>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddItemToCartHandler : IRequestHandler<AddItemToCart, bool>
    {
        private readonly IApplicationDbContext _context;

        public AddItemToCartHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(AddItemToCart request, CancellationToken cancellationToken)
        {
          var product = _context.Products.First(p => p.Id == request.ProductId);
            var cart = _context.Carts.Include(c => c.Items).ThenInclude(I => I.Product).FirstOrDefault();
            if(cart == null)
            {
                cart = new Domain.Entities.Cart();
                _context.Carts.Add(cart);
            }
            cart.AddToCart(product, request.Quantity);
           _context.SaveChanges();
            return Task.FromResult(true);

        }
    }
}
