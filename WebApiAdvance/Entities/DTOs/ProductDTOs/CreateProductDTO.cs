using WebApiAdvance.Entities.Common;
using WebApiAdvance.Entities.Enums;

namespace WebApiAdvance.Entities.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public string Currency { get; set; } 

        public PruductStatus status { get; set; }
    }
}
