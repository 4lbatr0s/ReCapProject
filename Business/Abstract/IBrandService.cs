using Core.Utilities.Results;
using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int BrandId);
        IDataResult<List<Brand>> GetByCountry(string countrName);
        IResult Add(Brand Brand);
        IResult Delete(Brand Brand);
        IResult Update(Brand Brand);
    }
}
