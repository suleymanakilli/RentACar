using Core.Utilites.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarManager
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetByBrandAndColorId(int brandId, int colorId);
        IResult TransactionTest(Car car);

        IDataResult<CarDetailDto> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByFilter(int brandId, int colorId);

    }
}
