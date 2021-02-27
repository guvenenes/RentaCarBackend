using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetCarsByBrandId(int Id);
        IDataResult<List<Product>> GetCarsByColorId(int Id);
        IDataResult<List<ProductDetailDto>> GetCarDetail();

        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}
