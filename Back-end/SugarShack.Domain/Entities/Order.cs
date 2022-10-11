using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Domain.Entities
{
    public class Order: BaseEntity
    {
      
        public IList<OrderLineItem> Items { get; set; }
        public Order()
        {
            Items = new List<OrderLineItem>();
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var item in Items)
            {
                total = total + (item.Quantity * item.Product.Price);
            }
            return total;
        }
    }
}
