using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarImageDal:IEntityRepository<CarImage>
    {
        public List<CarImage> GetByCarId(int carId);
        public CarImage GetFirstImageByCarId(int carId);

    }
}
