using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImgaeDal : EfEntityRepositoryBase<CarImage, VehicleContext>, ICarImageDal
    {
        public List<CarImage> GetByCarId(int carId)
        {
            using (VehicleContext context = new VehicleContext())
            {
                var result = from c in context.Cars
                             join ci in context.CarImages on c.Id equals ci.CarId
                             where c.Id == carId
                             select new CarImage
                             {
                                 Id = ci.Id,
                                 CarId = c.Id,
                                 CarImagePath = ci.CarImagePath,
                                 Date = ci.Date
                             };
                return result.ToList();
            }
        }

        public CarImage GetFirstImageByCarId(int carId)
        {
            using (VehicleContext context = new VehicleContext())
            {
                var result = from c in context.Cars
                             join ci in context.CarImages on c.Id equals ci.CarId
                             where c.Id == carId
                             select new CarImage
                             {
                                 Id = ci.Id,
                                 CarId = c.Id,
                                 CarImagePath = ci.CarImagePath,
                                 Date = ci.Date
                             };
                return result.ToList().ElementAt(0);
            }
        }
    }
}
