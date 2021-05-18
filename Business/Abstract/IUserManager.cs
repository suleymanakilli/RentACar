using Core.Entities.Concrete;
using Core.Utilites.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserManager
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<UserDto> GetUserDtoByMail(string email);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);

    }
}
