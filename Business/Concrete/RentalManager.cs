using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilites.Business;
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
    public class RentalManager : IRentalManager
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfReturnDateNull(rental));
            if (result==null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            return result;
            
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult CheckIfAvailable(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfReturnDateNull(rental));
            if (result==null)
            {
                return new SuccessResult(Messages.Added);
            }
            return result;

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Success);
        }

        public IDataResult<Rental> GetById(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId), Messages.Success);
        }

        public IDataResult<Rental> GetLastRentalById(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetLastRentalById(carId), Messages.Success);
        }

 

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckIfReturnDateNull(Rental rental)
        {
            var result = GetLastRentalById(rental.CarId);
            if (result.Data!=null)
            {
                if (result.Data.ReturnDate == null)
                {
                    return new ErrorResult(Messages.ReturnDateIsNull);
                }
                DateTime returnDateNew = (DateTime)result.Data.ReturnDate;
                TimeSpan substractedDate = returnDateNew.Subtract(rental.RentDate);
                if (substractedDate.TotalSeconds >= 0)
                {
                    return new ErrorResult(Messages.CarIsNotAvailable);
                }
                return new SuccessResult(Messages.Success);
            }
            return new SuccessResult();
            
        }
    }
}
