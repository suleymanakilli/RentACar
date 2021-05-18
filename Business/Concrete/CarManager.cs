using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    
    public class CarManager : ICarManager
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //[SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarManager.Get")]//Bunu yazma sebebimiz öyle bir durum olabilirki sadece car değil brand içinde cache kaldırmamız gerekebilir.
        //Ama şuanlık Car için Get ile başlayan metodların cache leri silindi
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car); //Bu haliyle çalışır ama daha temiz bir kod olması için aop ekleyeceğiz
            _carDal.Add(car);     
            return new SuccessResult(Messages.Added);
        }
        [CacheRemoveAspect("ICarManager.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }
        //[SecuredOperation("admin,car.add")]
        [CacheAspect]
        [PerformanceAspect(5)]
        
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => (brandId == 0 || c.BrandId == brandId) && (colorId == 0 || c.ColorId == colorId)));
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsByCarId(carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByFilter(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByFilter(brandId,colorId));
        }

        [TransactionScopeAspect]
        public IResult TransactionTest(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
        [CacheRemoveAspect("ICarManager.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
