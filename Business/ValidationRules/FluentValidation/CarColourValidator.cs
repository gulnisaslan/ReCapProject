using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarColourValidator : AbstractValidator<CarColour>
    {
        public CarColourValidator()
        {
            RuleFor(cc => cc.ColourName).NotEmpty();
            RuleFor(cc => cc.ColourName).MinimumLength(2);

        }
    }
}
