using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin,product.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail());
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == Id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == Id));
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car product)
        {
            _carDal.Update(product);
            return new SuccessResult(Messages.CarAdded);
        }
    }
}
