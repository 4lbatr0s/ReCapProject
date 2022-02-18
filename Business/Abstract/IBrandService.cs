using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        Task<IDataResult<List<Brand>>> GetAll();
        Task<IDataResult<Brand>> GetById(Guid BrandId);
        Task<IDataResult<List<Brand>>> GetByCountry(string countrName);
        Task<IResult> Add(BrandForCreationDto brandForCreationDto);
        Task<IResult> Delete(Brand Brand);
        Task<IResult> Update(Brand Brand);
    }
}
