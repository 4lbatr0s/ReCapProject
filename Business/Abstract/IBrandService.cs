using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(Guid BrandId);
        IDataResult<List<Brand>> GetByCountry(string countrName);
        IResult Add(BrandForCreationDto brandForCreationDto);
        IResult Delete(Guid guid);
        IResult Update(Brand Brand);
    }
}
