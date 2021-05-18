using Core.DataAccess.EntityFramework;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public Rental GetLastRentalById(int carId)
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId
                             
                             select new Rental { Id = r.Id, CarId = r.CarId,
                                 CustomerId = r.CustomerId, RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.OrderByDescending(x=>x.Id).FirstOrDefault();
            }
        }
    }
}
