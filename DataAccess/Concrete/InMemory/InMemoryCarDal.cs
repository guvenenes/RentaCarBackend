using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemoryProductDal
{
    public class InMemoryCarDal 
    {
        List<Car> _products;

        public InMemoryCarDal()
        {
            _products = new List<Car>{
            new Car{CarId = 1, BrandId = 1, ColorId = 253, DailyPrice = "100", Description = "iyidir iyi", ModelYear = "2017"},
            new Car{CarId = 2, BrandId = 15, ColorId = 336, DailyPrice = "50", Description = "iyi gibi ama kötü", ModelYear = "2005"},
            new Car{CarId = 3, BrandId = 27, ColorId = 343, DailyPrice = "70", Description = "ortalama bir deneyim", ModelYear = "2010"},
            new Car{CarId = 4, BrandId = 8, ColorId = 873, DailyPrice = "150", Description = "ıyüksek performans ve rahatlık", ModelYear = "2020"}

            };
        }

        public void Add(Car product)
        {
            _products.Add(product);
        }

        public void Delete(Car product)
        {
            Car productToDelete = _products.SingleOrDefault(p => p.CarId == product.CarId);
            _products.Remove(productToDelete);
        }

        public List<Car> GetAll()
        {
            return _products;
        }

        public List<Car> GetById(int Id)
        {
            return _products.Where(p => p.CarId == Id).ToList();
        }

        public void Update(Car product)
        {
            Car productToUpdate = _products.SingleOrDefault(p => p.CarId == product.CarId);
            productToUpdate.CarId = product.CarId;
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.ColorId = product.ColorId;
            productToUpdate.ModelYear = product.ModelYear;
            productToUpdate.DailyPrice = product.DailyPrice;
            productToUpdate.Description = product.Description;
        }
    }
}
