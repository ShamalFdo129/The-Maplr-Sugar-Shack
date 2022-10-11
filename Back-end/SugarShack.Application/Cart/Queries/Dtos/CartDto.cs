using SugarShack.Application.Common.Mappings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Cart.Queries.Dtos
{
    public class CartDto : IMapFrom<SugarShack.Domain.Entities.Cart>
    {
        public string? Name { get; set; } 
        public IList<CartLineItemDto> Items { get; set; } = new List<CartLineItemDto>();
    }
}
