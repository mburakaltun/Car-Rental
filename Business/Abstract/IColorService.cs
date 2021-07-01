using Core.Results;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        public IDataResult<List<Color>> GetAll();
        public IDataResult<Color> GetById(int colorId);
        public IResult Add(Color color);
        public IResult Update(Color color);
        public IResult Delete(Color color);
    }
}
