using Business.Abstract;
using Business.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Pay(CreditCard creditCard)
        {
            return new SuccessResult();
        }
    }
}
