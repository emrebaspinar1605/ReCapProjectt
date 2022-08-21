using Business.Constant;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            //predicate
            //fluent = akıcı kod dizesi
            RuleFor(c=>c.Id).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty().GreaterThan(0);
            RuleFor(c => c.ModelYear).LessThan(DateTime.Now.Year).GreaterThan((DateTime.Now.Year) - 25);
        }
       
    }
}
