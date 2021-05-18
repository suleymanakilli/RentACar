using Core.Utilites.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardManager
    {
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> GetByCustomerId(int customerId);
        IResult CheckIfValid(CreditCard creditCard);
        IResult Pay(CreditCard credit);

    }
}
