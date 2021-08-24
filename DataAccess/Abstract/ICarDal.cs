using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDTO> GetAllDetails();
        CarDetailDTO GetDetailsById(int carId);
        public List<CarDetailDTO> GetCarDetailsByBrandId(int brandId);
        public List<CarDetailDTO> GetCarDetailsByColorId(int colorId);
        public List<CarDetailDTO> GetCarDetailsBySearch(CarSearchDTO carSearchDTO);
    }
}
