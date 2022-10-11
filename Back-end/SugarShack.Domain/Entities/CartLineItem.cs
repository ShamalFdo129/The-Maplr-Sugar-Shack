using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Domain.Entities
{
    public class CartLineItem: BaseEntity
    {
        public Product Product { get; set; }= null!;

        public int Quantity { get; set; }

        public Cart Cart { get; set; } = null!;
        public CartLineItem()
        {

        }
       
        public CartLineItem(Product product)
        {
            Product = product;
        }
    }
}
