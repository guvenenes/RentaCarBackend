using Business.Abstract;
using Business.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IDataResult<List<CreditCard>> GetById(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_paymentDal.GetAll(c => c.CustomerId == customerId));
        }

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Pay(CreditCard creditCard)
        {
            return new SuccessResult();
        }

        public IResult Save(CreditCard credit)
        {
            _paymentDal.Add(credit);
            return new SuccessResult();
        }
    }
}
