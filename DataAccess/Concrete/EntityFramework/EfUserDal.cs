using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext()) 
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.Id == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public UserDto GetUserByMail(string email)
        {
            using (var context = new RentACarContext())
            {
                var result = from user in context.Users
                             where user.Email==email
                             select new UserDto { Id = user.Id, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName };
                return result.FirstOrDefault();
            }
        }
    }
}
