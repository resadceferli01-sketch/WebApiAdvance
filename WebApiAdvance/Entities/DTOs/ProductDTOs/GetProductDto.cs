using WebApiAdvance.Entities.Enums;

namespace WebApiAdvance.Entities.DTOs.ProductDTOs
{
    public class GetProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public string Currency { get; set; }

        public PruductStatus status { get; set; }

        public string CategoryName { get; set; }
    }
}
