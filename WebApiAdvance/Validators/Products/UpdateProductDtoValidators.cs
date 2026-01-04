using FluentValidation;
using WebApiAdvance.Entities.DTOs.ProductDTOs;

namespace WebApiAdvance.Validators.Products
{
    public class UpdateProductDtoValidators: AbstractValidator<CreateProductDTO>
    {

        public UpdateProductDtoValidators() 
        {
            RuleFor(p => p.Name)
        .NotEmpty().WithMessage("Ad bos ola bilmez")
        .NotNull().WithMessage("Ad deyerini daxil edin")
        .MinimumLength(3).WithMessage("Ad en az 3 simvoldan ibaret olmalidir");


            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description bos ola bilmez")
                .NotNull().WithMessage("Description deyeri daxil edin");
        }
    }
}
