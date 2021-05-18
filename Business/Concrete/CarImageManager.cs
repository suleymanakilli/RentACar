using Business.Abstract;
using Business.Constants;
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
    public class CarImageManager : ICarImageManager
    {
        ICarImageDal _carImage;

        public CarImageManager(ICarImageDal carImage)
        {
            _carImage = carImage;
        }
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(DoesCarHaveMoreThanFiveImages(carImage.CarId));
            if (result.IsSuccessful)
            {
                carImage.Date = DateTime.Now;
                _carImage.Add(carImage);
                return new SuccessResult(Messages.Added);
            }
            return result;
            
        }

        public IResult Delete(CarImage carImage)
        {
            _carImage.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImage.GetAll());
        }

        public IResult Update(CarImage carImage)
        {
            _carImage.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        private IResult DoesCarHaveMoreThanFiveImages(int carId)
        {
            int count = _carImage.GetAll(c => c.Id == carId).Count();
            return count>=5 ? new ErrorResult(Messages.CarImageLimitExceeded):new SuccessResult() ;
        }
    }
}
