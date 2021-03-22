using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<Image> GetById(int id);
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetImagesByCarId(int id);
        IResult Add(IFormFile file, Image image);
        IResult Delete(Image image);
        IResult Update(IFormFile file, Image image);
    }
}
