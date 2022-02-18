using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly IMapper _mapper;
        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }
        public async Task<IResult> Add(RentalForCreationDto rentalForCreationDto)
        {
            var rental = _mapper.Map<Rental>(rentalForCreationDto);
            await _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public async Task<IResult> Delete(Rental rental)
        {
            await _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public async Task<IDataResult<List<Rental>>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(await _rentalDal.GetAll(), Messages.AllRentalsListed);
        }

        public async Task<IDataResult<Rental>> GetById(Guid rentalId)
        {
            return new SuccessDataResult<Rental>(await _rentalDal.Get(r => r.RentalId == rentalId));
        }

        public async Task<IDataResult<List<RentalDetailDto>>> GetRentalDetails()
        {
            var result = await _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>();
        }

        public async Task<IResult> Update(Rental rental)
        {
            await _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
