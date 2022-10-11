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

    public record RemoveFromCart : IRequest<bool>
    {
        public int LineItemId { get; set; }

    }

    public class RemoveFromCartHandler : IRequestHandler<RemoveFromCart, bool>
    {
        private readonly IApplicationDbContext _context;

        public RemoveFromCartHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(RemoveFromCart request, CancellationToken cancellationToken)
        {
            var item = _context.CartLineItems.FirstOrDefault(x => x.Id == request.LineItemId);
            if (item != null)
            {
                _context.CartLineItems.Remove(item);
                _context.SaveChanges();
                return Task.FromResult(true);
            }

            return Task.FromResult(false);

        }
    }
}
