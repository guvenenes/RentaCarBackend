using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemoryProductDal
{
    public class InMemoryProductDal 
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>{
            new Product{Id = 1, BrandId = 1, ColorId = 253, DailyPrice = 100, Description = "iyidir iyi", ModelYear = "2017"},
            new Product{Id = 2, BrandId = 15, ColorId = 336, DailyPrice = 50, Description = "iyi gibi ama kötü", ModelYear = "2005"},
            new Product{Id = 3, BrandId = 27, ColorId = 343, DailyPrice = 70, Description = "ortalama bir deneyim", ModelYear = "2010"},
            new Product{Id = 4, BrandId = 8, ColorId = 873, DailyPrice = 150, Description = "ıyüksek performans ve rahatlık", ModelYear = "2020"}

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.Id == product.Id);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetById(int Id)
        {
            return _products.Where(p => p.Id == Id).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.Id == product.Id);
            productToUpdate.Id = product.Id;
            productToUpdate.BrandId = product.BrandId;
            productToUpdate.ColorId = product.ColorId;
            productToUpdate.ModelYear = product.ModelYear;
            productToUpdate.DailyPrice = product.DailyPrice;
            productToUpdate.Description = product.Description;
        }
    }
}
