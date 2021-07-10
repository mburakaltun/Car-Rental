using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(
                CheckCarImageCountLimitForCar(carImage.CarId)
                );
            if(!result.Success) 
            {
                return new ErrorResult(result.Message);
            }
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(b => b.Id == carImageId));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(
                CheckCarImageExists(carId)
                );
            if(!result.Success)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>());
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageCountLimitForCar(int carId)
        {
            var count = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(count >= 5)
            {
                return new ErrorResult(Messages.CarImageCountLimitExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if(result.Count == 0)
            {
                return new ErrorResult(Messages.CarImageDoesNotExist);
            }
            return new SuccessResult();
        }
    }
}
