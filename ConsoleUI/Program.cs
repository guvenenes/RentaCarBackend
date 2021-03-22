using Business.Concrete;
using Business.Constans;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
   class Program
    {
         static void Main(string[] args)
        {
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.GetAll();
            CarManager productManager = new CarManager(new EfCarDal());
            
            foreach (var car in productManager.GetAll().Data)
            {
                Console.WriteLine(car.BrandId);
            }
            
            //productManager.GetCarsByColorId(32);
        }
    }
}
