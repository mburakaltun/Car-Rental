using Core.Results;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        public IDataResult<List<CarImage>> GetAll();
        public IResult Add(CarImage carImage);
        public IResult Update(CarImage carImage);
        public IResult Delete(CarImage carImage);
        public IResult AddByCarId(CarImage carImage);
        public IDataResult<List<CarImage>> GetByCarId(int carId);
        public IDataResult<CarImage> GetFirstImageByCarId(int carId);
    }
}
