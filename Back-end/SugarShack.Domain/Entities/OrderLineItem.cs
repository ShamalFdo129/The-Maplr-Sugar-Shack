namespace SugarShack.Domain.Entities
{
    public class OrderLineItem : BaseEntity
    {
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public Order Order { get; set; } = null!;
        public OrderLineItem()
        {

        }

        public OrderLineItem(Product product)
        {
            Product = product;
        }
    }
}
