using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(Guid customerId);
        IResult Add(CustomerCreationDto customer);
        IResult Update(Customer customer);
        IResult Delete(Guid id);
    }
}
