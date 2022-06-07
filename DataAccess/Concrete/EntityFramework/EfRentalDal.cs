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
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             join u in context.Users
                             on cs.UserId equals u.Id
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             
                                
                             select new RentalDetailDto
                             {
                                CustomerId = cs.CustomerId,
                                CarId = r.CarId,
                                ReturnDate = r.ReturnDate,
                                RentDate = r.RentDate,
                                CompanyName = cs.CompanyName, 
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                BrandName = b.BrandName,
                             };
                return result.ToList();
                                
            }
        }
    }
}
