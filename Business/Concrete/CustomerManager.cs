using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult AddUser(Customer customer)
        {
            using (RentACarContext context = new RentACarContext())
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);

            }
        }
    }
}
