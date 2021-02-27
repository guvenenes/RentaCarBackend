using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                if (entity.DailyPrice >= 0 && entity.Description.Length >= 2)
                {
                    var AddedEntity = context.Entry(entity);
                    AddedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("HATA!! Günlük ücrette veya açıklamada sıkıntı olabilir!");
                }
            }
        }

        public void Delete(Product entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public Product GetById(Expression<Func<Product, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
