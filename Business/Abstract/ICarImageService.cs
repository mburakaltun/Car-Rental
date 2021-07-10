using Core.Results;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        public IDataResult<List<CarImage>> GetAll();
        public IDataResult<CarImage> GetById(int brandId);
        public IResult Add(CarImage brand);
        public IResult Update(CarImage brand);
        public IResult Delete(CarImage brand);
    }
}
