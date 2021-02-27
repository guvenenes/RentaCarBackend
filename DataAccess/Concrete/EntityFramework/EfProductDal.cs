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
    public class EfProductDal : EfEntityRepositoryBase<Product, RentACarContext>, IProductDal
    {
        public List<ProductDetailDto> GetCarDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands
                             on p.BrandId equals b.BrandId
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             select new ProductDetailDto { ProductId = p.Id, BrandId = b.BrandId, BrandName = b.BrandName, ColorName = c.ColorName, DailyPrice = p.DailyPrice };
                return result.ToList();
            }
        }   
    }
}
