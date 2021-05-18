using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CardNumber.Length).Equal(16);
            RuleFor(c => c.CVV.Length).Equal(3);
        }
    }
}
