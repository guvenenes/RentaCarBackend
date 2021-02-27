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
            //productManager.GetAll();
            ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.GetCarDetail();
        }
    }
}
