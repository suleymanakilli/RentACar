using Core.Utilites.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalManager
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetById(int carId);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetLastRentalById(int carId);
        IResult CheckIfAvailable(Rental rental);
    }
}
