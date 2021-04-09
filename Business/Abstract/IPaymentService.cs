using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(CreditCard creditCard);
        IResult Save(CreditCard credit);
        IDataResult<List<CreditCard>> GetById(int customerId);
    }
}
