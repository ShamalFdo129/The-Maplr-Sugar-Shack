using FluentValidation;

using SugarShack.Application.Common.Interfaces;

namespace SugarShack.Application.Cart.Commands
{
    public class RemoveFromCartValidator: AbstractValidator<RemoveFromCart>
    {
        private readonly IApplicationDbContext _context;
        public RemoveFromCartValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(i => i.LineItemId).MustAsync(ISValidLineItem).WithMessage("Line Item Id is Invalid!.");

        }

        public async Task<bool> ISValidLineItem(int itemId, CancellationToken cancellationToken)
        {
            return await _context.CartLineItems.FindAsync(itemId) != null ? true : false;
        }
    }
}
