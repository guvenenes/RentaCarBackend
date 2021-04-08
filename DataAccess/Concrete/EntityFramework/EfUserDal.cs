using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

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
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
        public List<UserDetailDto> GetUserDetail(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new RentACarContext())
            {
                IQueryable<UserDetailDto> userDetailDtos = from u in filter is null ? context.Users : context.Users.Where(filter)
                                                           join oc in context.UserOperationClaims
                                                           on u.Id equals oc.UserId
                                                           join c in context.OperationClaims
                                                           on oc.Id equals c.Id
                                                           select new UserDetailDto
                                                           {
                                                               UserId = u.Id,
                                                               FirstName = u.FirstName,
                                                               LastName = u.LastName,
                                                               Email = u.Email,
                                                               Claim = c.Name,
                                                           };
                return userDetailDtos.ToList();

            }
        }
    }
}
