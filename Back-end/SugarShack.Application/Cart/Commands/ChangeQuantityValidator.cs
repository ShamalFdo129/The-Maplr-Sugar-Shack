using FluentValidation;

using SugarShack.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Cart.Commands
{
    public class ChangeQuantityValidator : AbstractValidator<ChangeQuantity>
    {
        private readonly IApplicationDbContext _context;
        public ChangeQuantityValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(i => i.Quantity).GreaterThanOrEqualTo(1).WithMessage("Quantity should be greater than one.");
            RuleFor(i => i.LineItemId).MustAsync(IsValidLineItem).WithMessage("Line Item Id is Invalid!.");
        }

        public async Task<bool> IsValidLineItem(int itemId, CancellationToken cancellationToken)
        {
            return await _context.CartLineItems.FindAsync(itemId) != null ? true : false;
        }
    }
}
