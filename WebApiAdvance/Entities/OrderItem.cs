using WebApiAdvance.Entities.Common;

namespace WebApiAdvance.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
