using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Domain.Entities
{
    public class Cart: BaseEntity
    {
        public string Name { get; set; } = "Shamal's Cart";
        public IList<CartLineItem> Items { get; set; }
        public Cart()
        {
            Items = new List<CartLineItem>();
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (CartLineItem item in Items)
            {
                total = total + (item.Quantity * item.Product.Price);
            }
            return total;
        }

        public bool AddToCart(Product product, int quantity)
        {
            if (Items.Where(i => i.Product.Id == product.Id).Count() == 0)
            {
                Items.Add(new CartLineItem(product) { Quantity = quantity });
            }
            else
            {
                var lineItem = Items.Where(i => i.Product.Id == product.Id).FirstOrDefault();
                if(lineItem != null)
                {
                    lineItem.Quantity += quantity;
                }
            }
            return true;
        }

       
    }
}
