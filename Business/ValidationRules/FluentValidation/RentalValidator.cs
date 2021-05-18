using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).Must(RentDateValidation).WithMessage("Please enter valid rent date");
            RuleFor(r => r.ReturnDate).Must(ReturnDateValidation).WithMessage("Please enter valid return date");
            RuleFor(r => r).Must(DateValidation).WithMessage("Car is not available at that interval time");
        }


        public bool RentDateValidation(DateTime rentDate)
        {
            TimeSpan substractedDate = rentDate.Subtract(DateTime.Today);
            if (substractedDate.TotalSeconds>=0)
            {
                return true;
            }
            return false;
        }
        public bool ReturnDateValidation(DateTime? returnDate)
        {
            if (returnDate != null)
            {
                DateTime returnDateNew = (DateTime)returnDate;
                
                TimeSpan substractedDate = returnDateNew.Subtract(DateTime.Today);
                
                if (substractedDate.TotalSeconds >= 0)
                {
                    return true;
                }
                return false;
            }
            return true;
            
        }
        public bool DateValidation(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                DateTime returnDateNew = (DateTime)rental.ReturnDate;
                TimeSpan substractedDate = returnDateNew.Subtract(rental.RentDate);
                if (substractedDate.TotalSeconds >= 0)
                {
                    return true;
                }
                return false;
            }
            return true;
            
        }
    }
}
