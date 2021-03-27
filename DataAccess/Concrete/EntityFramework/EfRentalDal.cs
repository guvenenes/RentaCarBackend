using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                CarId = r.CarId,
                                ReturnDate = r.ReturnDate,
                                RentDate = r.RentDate,
                                CompanyName = c.CompanyName, 
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                             };
                return result.ToList();
                                
            }
        }
    }
}
