using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(IFormFile file, Image image)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));
            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Delete(Image image)
        {
            FileHelper.Delete(image.ImagePath);           
            _imageDal.Delete(image);   
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<Image> GetById(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.GetById(p => p.Id == id));

        }

        public IDataResult<List<Image>> GetImagesByCarId(int carId)
        {
            var result = _imageDal.GetAll(c => c.CarId == carId);
            if (result.Any()) 
            { 
                return new SuccessDataResult<List<Image>>(result); 
            }
            else
            {
                return new SuccessDataResult<List<Image>>(new List<Image>
            {
                new Image{  CarId = carId,  ImagePath = "\\Images\\default.jpg", Date = DateTime.Now }
            });
            }
            
            
        }

        public IResult Update(IFormFile file, Image image)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));
            if (result!=null)
            {
                return result;
            }
            
            image.ImagePath = FileHelper.Update(_imageDal.GetById(p=>p.Id == image.Id).ImagePath, file);
            image.Date = DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult();
        }
        private IResult CheckImageLimitExceeded(int carId)
        {
            var imageCount = _imageDal.GetAll(p => p.CarId == carId).Count;
            if (imageCount >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
