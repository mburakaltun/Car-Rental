using Core.Results;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        public IDataResult<List<Car>> GetAll();
        public IDataResult<Car> GetById(int Id);
        public IResult Add(Car car);
        public IResult Update(Car car);
        public IResult Delete(Car car);
        public IDataResult<List<Car>> GetByColorId(int colorId);
        public IDataResult<List<Car>> GetByBrandId(int brandId);
        public IDataResult<List<CarDetailDTO>> GetAllDetails();
        public IDataResult<CarDetailDTO> GetDetailsById(int id);
        public IDataResult<List<CarDetailDTO>> GetCarDetailsByBrandId(int brandId);
        public IDataResult<List<CarDetailDTO>> GetCarDetailsByColorId(int brandId);
        public IDataResult<List<CarDetailDTO>> GetCarDetailsBySearch(CarSearchDTO carSearchDTO);
    }
}
