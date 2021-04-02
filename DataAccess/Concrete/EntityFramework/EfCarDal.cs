using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        
        public List<CarDetailDto> GetCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                IQueryable<CarDetailDto> carDetails = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                                                      join b in context.Brands
                                                      on c.BrandId equals b.BrandId
                                                      join cl in context.Colors
                                                      on c.ColorId equals cl.ColorId

                                                      select new CarDetailDto
                                                      {
                                                          CarId = c.CarId,
                                                          BrandId = b.BrandId,
                                                          ColorId = cl.ColorId,
                                                          CarName = c.CarName,
                                                          BrandName = b.BrandName,
                                                          ColorName = cl.ColorName,
                                                          ModelYear = c.ModelYear,
                                                          DailyPrice = c.DailyPrice.ToString(),
                                                          Description = c.Description,
                                                          IsRentable = !context.Rentals.Any(r => r.CarId == c.CarId && r.ReturnDate > DateTime.Now),
                                                          ImagePath = (from i in context.Images where i.CarId == c.CarId select i.ImagePath).FirstOrDefault()
                                                      };

                return carDetails.ToList();


            }
        }
    }
}
