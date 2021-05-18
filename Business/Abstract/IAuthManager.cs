using Core.Entities.Concrete;
using Core.Utilites.Results;
using Core.Utilites.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthManager
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
