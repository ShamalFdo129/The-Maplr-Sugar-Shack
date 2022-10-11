using FluentValidation;

using SugarShack.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Cart.Commands
{
    public class AddItemToCartValidator: AbstractValidator<AddItemToCart>
    {
        private readonly IApplicationDbContext _context;
        public AddItemToCartValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(i => i.Quantity).GreaterThanOrEqualTo(1).WithMessage("Quantity should be greater than one.");
           RuleFor(i => i.ProductId).MustAsync(IsValidProduct).WithMessage("Product Id is not valid.");

        }

        public async Task<bool> IsValidProduct(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(productId) != null ? true : false;
        }
    }
}
