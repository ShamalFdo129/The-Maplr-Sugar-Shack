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

namespace SugarShack.Application.Order.Commands
{
   
    public record PlaceOrder : IRequest<bool>
    {
        public int CardId { get; set; }
    }

    public class PlaceOrderHandler : IRequestHandler<PlaceOrder, bool>
    {
        private readonly IApplicationDbContext _context;

        public PlaceOrderHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(PlaceOrder request, CancellationToken cancellationToken)
        {
            var cart = _context.Carts.Where(c=> c.Id == request.CardId).Include(c => c.Items).ThenInclude(I => I.Product).FirstOrDefault();

            if (cart != null)
            {
                var orderLineItems = cart.Items.Select(i => new OrderLineItem() { Product = i.Product, Quantity = i.Quantity }).ToList();
                var order = new SugarShack.Domain.Entities.Order();
                order.Items = orderLineItems;
                _context.Orders.Add(order);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
 
            return Task.FromResult(false);
        }
    }
}
