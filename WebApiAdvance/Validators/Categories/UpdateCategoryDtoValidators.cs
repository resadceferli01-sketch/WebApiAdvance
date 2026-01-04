using FluentValidation;
using WebApiAdvance.Entities.DTOs.CategoryDTOs;

namespace WebApiAdvance.Validators.Categories
{
    public class UpdateCategoryDtoValidators:AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDtoValidators()
        {
            RuleFor(c => c.Name)
             .NotEmpty().WithMessage("Ad bos ola bilmez")
             .NotNull().WithMessage("Ad deyerini daxil edin")
             .MinimumLength(3).WithMessage("Ad en az 3 simvoldan ibaret olmalidir");


            RuleFor(c => c.Description)
                    .NotEmpty().WithMessage("Description bos ola bolmez")
                    .NotNull().WithMessage("Description daxil edin");
        }
    }
}
