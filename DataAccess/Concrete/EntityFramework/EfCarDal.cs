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
        public CarDetailDTO GetDetailsById(int carId)
        {
            using (VehicleContext context = new VehicleContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where c.Id == carId
                             select new CarDetailDTO
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice                              
                             };
                return result.Single();
            }
        }

        public List<CarDetailDTO> GetAllDetails()
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
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDTO> GetCarDetailsByBrandId(int brandId)
        {
            using (VehicleContext context = new VehicleContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where b.Id == brandId
                             select new CarDetailDTO
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDTO> GetCarDetailsByColorId(int colorId)
        {
            using (VehicleContext context = new VehicleContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where clr.Id == colorId
                             select new CarDetailDTO
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDTO> GetCarDetailsByColorIdAndBrandId(int colorId, int brandId)
        {
            using (VehicleContext context = new VehicleContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where clr.Id == colorId
                             where b.Id == brandId
                             select new CarDetailDTO
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDTO> GetCarDetailsBySearch(CarSearchDTO productSearchDTO)
        {
            using (VehicleContext context = new VehicleContext())
            {
                var query = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             select new{ c, b, clr};
          
                if(productSearchDTO.brandId != null)
                {
                    query = query.Where(output => output.b.Id == productSearchDTO.brandId);
                }
                if(productSearchDTO.colorId != null)
                {
                    query = query.Where(output => output.clr.Id == productSearchDTO.colorId);
                }

                var result = query.Select(output => new CarDetailDTO
                {
                    CarId = output.c.Id,
                    BrandName = output.b.Name,
                    ColorName = output.clr.Name,
                    DailyPrice = output.c.DailyPrice
                });

                return result.ToList();
            }
        }
    }
}
