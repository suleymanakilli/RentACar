using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(10);
            RuleFor(c => c.DailyPrice).GreaterThan(20);
            RuleFor(c => c.ModelYear).GreaterThan(1990);
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(c => c.CarName).MinimumLength(2);
        }
    }
}
