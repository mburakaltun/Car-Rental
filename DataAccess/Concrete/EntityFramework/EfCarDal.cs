using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, VehicleContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (VehicleContext context = new VehicleContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             select new CarDetailDTO
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,                            
                                 ColorName = clr.Name
                             };
                return result.ToList();
            }
        }
    }
}
