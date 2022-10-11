using SugarShack.Application.Common.Dtos;
using SugarShack.Application.Common.Mappings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Cart.Queries.Dtos
{
    public class CartLineItemDto: IMapFrom<SugarShack.Domain.Entities.CartLineItem>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductDto? Product { get; set; }
    }
}
