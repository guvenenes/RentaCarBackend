using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        void Add(User user);
        List<UserDetailDto> GetUserDetail(string email);
        IDataResult<List<User>> GetAll();
    }
}
