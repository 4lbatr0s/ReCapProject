using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<List<Customer>>> GetAll();
        Task<IDataResult<Customer>> GetById(Guid customerId);
        Task<IResult> Add(CustomerCreationDto customer);
        Task<IResult> Update(Customer customer);
        Task<IResult> Delete(Customer customer);
    }
}
