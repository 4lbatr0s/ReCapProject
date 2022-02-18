using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CustomerCreationDto customerCreationDto)
        {
            var customer = _mapper.Map<Customer>(customerCreationDto);
            await _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        

        public async Task<IResult> Delete(Customer result)
        {
            await _customerDal.Delete(result);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public async Task<IDataResult<List<Customer>>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(await _customerDal.GetAll(), Messages.AllCustomersListed);
        }

        public async Task<IDataResult<Customer>> GetById(Guid customerId)
        {
            return new SuccessDataResult<Customer>(await _customerDal.Get(c => c.CustomerId == customerId));
        }

        public  async Task<IResult> Update(Customer customer)
        {
            await _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
