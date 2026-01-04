using WebApiAdvance.Entities.Enums;

namespace WebApiAdvance.Entities.DTOs.CategoryDTOs
{
    public class GetCategoryDTO
    {
        public string Name {  get; set; }
        public string Description { get; set; }

        public CategoryStatus   status { get; set; }
    }
}
