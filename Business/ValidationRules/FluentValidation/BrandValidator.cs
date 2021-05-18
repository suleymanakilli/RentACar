using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            //RuleFor(b => b.BrandName).MinimumLength(2);//Bunu kendimizde yazabiliriz

            RuleFor(b => b.BrandName).Must(MinLength).WithMessage("Mİn length should be 2 custom");
            
        }
        public bool MinLength(string name)
        {
            int length = name.Length;
            if (length >= 2)
            {
                return true;
            }
            return false;
        }
    }
}
