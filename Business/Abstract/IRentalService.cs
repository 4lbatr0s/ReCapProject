using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        Task<IDataResult<List<Rental>>> GetAll();
        Task<IDataResult<List<RentalDetailDto>>> GetRentalDetails();
        Task<IDataResult<Rental>> GetById(Guid rentalId);
        Task<IResult> Add(RentalForCreationDto rental);
        Task<IResult> Delete(Rental rental);
        Task<IResult> Update(Rental rental);
    }
}
