using AutoMapper;
using WebApiAdvance.Entities.Common;
using WebApiAdvance.Entities.DTOs.CategoryDTOs;

namespace WebApiAdvance.Profiles
{
    public class CategoryProfiles: Profile
    {
        public CategoryProfiles()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<Category, CreateCategoryDTO>();

            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<Category, UpdateCategoryDTO>();

            CreateMap<Category,GetCategoryDTO>();

            
        }

    }
}
