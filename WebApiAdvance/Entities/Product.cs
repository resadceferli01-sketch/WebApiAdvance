using WebApiAdvance.Entities.Enums;

namespace WebApiAdvance.Entities.Common
{
    public class Product:BaseEntity
    {

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPrice {  get; set; }

        public string Currency { get; set; } = "AZN";

        public PruductStatus status { get; set; }
    }
}
