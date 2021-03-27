using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             //join r in context.Rentals
                             //on c.CustomerId equals r.CustomerId
                             select new CustomerDetailDto { 
                                 CustomerId = c.CustomerId,
                                 UserId = u.Id, 
                                 CompanyName = c.CompanyName,
                                 Email = u.Email, 
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName     };
                                 
                return result.ToList();
            }
        }
    }
}
