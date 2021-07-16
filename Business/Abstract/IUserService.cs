using Core.Entities.Concrete;
using Core.Results;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IDataResult<List<User>> GetAll();
        public IDataResult<User> GetById(int userId);
        public IResult Add(User user);
        public IResult Update(User user);
        public IResult Delete(User user);
        public IDataResult<User> GetByEmail(string email);
        public IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
