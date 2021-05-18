using Core.Utilites.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandManager
    {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<Brand> GetById( int brandId);
        IDataResult<List<Brand>> GetAll();
    }
}
