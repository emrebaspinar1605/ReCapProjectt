using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).NotNull();
            RuleFor(c => c.ModelYear).Must(NotOldCar);

            RuleFor(c => c.DailyPrice).GreaterThan(350);
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).NotEmpty();

            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.BrandId).GreaterThan(0);

            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.ColorId).GreaterThan(0);

            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).MaximumLength(50);
            RuleFor(c => c.Description).NotNull();
            RuleFor(c => c.Description).NotEmpty();

        }

        private bool NotOldCar(short arg)
        {
            if (arg >= 1985) return true; return false;
        }
    }
}
