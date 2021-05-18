using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardManager
    {
        ICreditCardDal _creditCard;
        public CreditCardManager(ICreditCardDal creditCard)
        {
            _creditCard = creditCard;

        }
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _creditCard.Add(creditCard);
            return new SuccessResult(Messages.Added);
        }
        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult CheckIfValid(CreditCard creditCard)
        {
            return new SuccessResult();

        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCard.Delete(creditCard);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll(c=>c.CustomerId==customerId));
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Pay(CreditCard creditCard)
        {
            return new SuccessResult(Messages.Success);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCard.Update(creditCard);
            return new SuccessResult(Messages.Updated);
        }
    }
}
