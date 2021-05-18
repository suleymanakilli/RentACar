using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,RentACarContext>,ICarDal
    {
        public CarDetailDto GetCarDetailsByCarId(int carId)
        {
            List<string> imagePathList = getImageList(carId);
            using (RentACarContext context=new RentACarContext())
            {
                
                                

                    var result = from c in context.Cars
                             where c.Id == carId
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join ci in context.CarImages on c.Id equals ci.CarId into ps
                             from ci in ps.DefaultIfEmpty()

                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 ImagePath = imagePathList.ToList()
                             };
                return result.FirstOrDefault();
            }
        }

        public static List<string> getImageList(int carId)
        {
            
            using (RentACarContext context = new RentACarContext())
            {
                var imagePathList = from c in context.Cars
                                    where c.Id == carId
                                    join ci in context.CarImages on c.Id equals ci.CarId into ps
                                    from ci in ps.DefaultIfEmpty()
                                    select (ci == null ? "images/Default_Image.jpg" : ci.ImagePath);
                return imagePathList.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByFilter(int brandId,int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
               

                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             join ci in context.CarImages on c.Id equals ci.CarId into ps
                             from ci in ps.DefaultIfEmpty()
                             
                             select new CarDetailDto
                             {
                                 Id=c.Id,
                                 Description=c.Description,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 BrandId=c.BrandId,
                                 ColorId=c.ColorId,
                                 //ImagePath = ci == null ? "Images/Default_Image.jpg"  : ci.ImagePath
                                 ImagePath= getImageList(c.Id)
                             };

                var distinctItems = result.Distinct();
                return distinctItems.AsEnumerable().Where(c => (brandId == 0 || c.BrandId == brandId) && (colorId == 0 || c.ColorId == colorId)).ToList();
                
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {


                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             join ci in context.CarImages on c.Id equals ci.CarId into ps
                             from ci in ps.DefaultIfEmpty()

                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Description = c.Description,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 //ImagePath = ci == null ? "Images/Default_Image.jpg"  : ci.ImagePath
                                 ImagePath = getImageList(c.Id)
                             };

                var distinctItems = result.Distinct();
                return distinctItems.ToList() ;

            }
        }
    }
}
