using System.Data;
using WebApiAdvance.Entities.Common;

namespace WebApiAdvance.Entities
{
    public class Order : BaseEntity

    {
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }


        public List<OrderItem>orderItems { get; set; }


    }
}
