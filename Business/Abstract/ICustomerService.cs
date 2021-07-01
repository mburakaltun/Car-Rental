using Core.Results;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public IDataResult<List<Customer>> GetAll();
        public IDataResult<Customer> GetById(int customerId);
        public IResult Add(Customer customer);
        public IResult Update(Customer customer);
        public IResult Delete(Customer customer);
    }
}
