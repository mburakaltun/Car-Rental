using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }


        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        public IResult Add(Car car)
        {
            var context = new ValidationContext<Car>(car);
            CarValidator carValidator = new CarValidator();
            var result = carValidator.Validate(context);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

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

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),"Cars are fecthed by brand id");
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), "Cars are fecthed by color id");
        }

        public IDataResult<CarDetailDTO> GetDetailsById(int id)
        {
            return new SuccessDataResult<CarDetailDTO>(_carDal.GetDetailsById(id));
        }

        public IDataResult<List<CarDetailDTO>> GetAllDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetAllDetails());
        }
    }
}
