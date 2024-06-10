using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidation : AbstractValidator<Brand>
    {
        public BrandValidation()
        {
            RuleFor(c => c.BrandName).NotEmpty();
            RuleFor(c => c.BrandName).NotNull();
            RuleFor(c => c.BrandName).MinimumLength(2);
            RuleFor(c => c.BrandName).MaximumLength(2);
        }
    }
}
