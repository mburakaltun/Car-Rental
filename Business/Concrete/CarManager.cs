using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect(duration:10)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var carDetail = _carDal.GetDetailsById(car.Id);
            if (carDetail.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else if (carDetail.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),"Cars are fecthed by brand id");
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), "Cars are fecthed by color id");
        }

        [CacheAspect(duration: 10)]
        public IDataResult<CarDetailDTO> GetDetailsById(int id)
        {
            return new SuccessDataResult<CarDetailDTO>(_carDal.GetDetailsById(id));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<CarDetailDTO>> GetAllDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetAllDetails());
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetailsByBrandId(brandId));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetailsByColorId(colorId));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailsBySearch(CarSearchDTO carSearchDTO)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetailsBySearch(carSearchDTO));
        }
    }
}
