using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<Rental> GetById(Guid rentalId);
        IResult Add(RentalForCreationDto rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
    }
}
