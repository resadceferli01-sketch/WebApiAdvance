using AutoMapper;
using WebApiAdvance.Entities.Common;
using WebApiAdvance.Entities.DTOs.ProductDTOs;

namespace WebApiAdvance.Profiles
{
    public class ProductProfiles:Profile
    {
        public ProductProfiles()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product, CreateProductDTO>();

            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Product, UpdateProductDTO>();
        }
    }
}
