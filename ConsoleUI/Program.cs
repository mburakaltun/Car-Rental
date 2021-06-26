using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
