using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand Brand)
        {
            _brandDal.Add(Brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IResult Delete(Brand Brand)
        {
            _brandDal.Delete(Brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.AllBrandsListed);
        }

        public IDataResult<List<Brand>> GetByCountry(string countrName)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(c => c.BrandCountry == countrName));
        }

        public IDataResult<Brand> GetById(int BrandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.BrandId == BrandId));
        }

        public IResult Update(Brand Brand)
        {
            _brandDal.Update(Brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}