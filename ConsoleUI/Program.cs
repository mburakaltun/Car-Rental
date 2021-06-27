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
            
            foreach (var carDto in carManager.GetCarDetails())
            {
                Console.WriteLine(carDto.CarId + " " + carDto.ColorName + " " + carDto.BrandName);
            }
        }
    }
}
