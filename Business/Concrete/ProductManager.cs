using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            using (RentACarContext context = new RentACarContext())
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.CarAdded);
            }
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<List<ProductDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetCarDetail());
        }

        public IDataResult<List<Product>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.BrandId == Id));
        }

        public IDataResult<List<Product>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ColorId == Id));
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.CarAdded);
        }
    }
}
