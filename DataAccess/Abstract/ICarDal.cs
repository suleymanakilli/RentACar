using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        CarDetailDto GetCarDetailsByCarId(int carId);
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsByFilter(int brandId,int colorId);
    }
}
