using WebApiAdvance.Entities.Enums;

namespace WebApiAdvance.Entities.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryStatus Status { get; set; }

    }
}
