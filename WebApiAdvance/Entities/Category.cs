using WebApiAdvance.Entities.Enums;

namespace WebApiAdvance.Entities.Common
{
    public class Category: BaseEntity

    {

        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryStatus Status { get; set; }

        public List<Product> Products {  get; set; }

    }
}
