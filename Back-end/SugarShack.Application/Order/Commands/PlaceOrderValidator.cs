using FluentValidation;

using SugarShack.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Order.Commands
{
    public class PlaceOrderValidator: AbstractValidator<PlaceOrder>
    {
        private readonly IApplicationDbContext _context;
        public PlaceOrderValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(i => i.CardId).MustAsync(IsValidCart).WithMessage("Cart Id is Invalid!.");

        }

        public async Task<bool> IsValidCart(int cartId, CancellationToken cancellationToken)
        {
            return await _context.Carts.FindAsync(cartId) != null ? true : false;
        }
    }
}
