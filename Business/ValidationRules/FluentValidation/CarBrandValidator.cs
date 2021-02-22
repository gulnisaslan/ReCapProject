using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarBrandValidator : AbstractValidator<CarBrand>
    {
        public CarBrandValidator()
        {
            RuleFor(cb => cb.BrandName).NotEmpty();
            RuleFor(cb => cb.BrandName).MinimumLength(2);


        }
    }
}
