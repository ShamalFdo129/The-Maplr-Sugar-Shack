using AutoMapper;

using MediatR;

using SugarShack.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Cart.Commands
{

    public record ChangeQuantity : IRequest<bool>
    {
        public int LineItemId { get; set; }
        public int Quantity { get; set; }
    }

    public class ChangeQuantityHandler : IRequestHandler<ChangeQuantity, bool>
    {
        private readonly IApplicationDbContext _context;

        public ChangeQuantityHandler(IApplicationDbContext context)
        {
            _context = context;

        }

        public Task<bool> Handle(ChangeQuantity request, CancellationToken cancellationToken)
        {
            var item = _context.CartLineItems.FirstOrDefault(x => x.Id == request.LineItemId);
            if (item != null)
            {
                item.Quantity = request.Quantity;
                _context.SaveChanges();
                return Task.FromResult(true);
            }

            return Task.FromResult(false);

        }
    }
}
