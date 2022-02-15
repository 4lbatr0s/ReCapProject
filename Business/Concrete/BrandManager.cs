using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;
using AutoMapper;
using Entities.Dto;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;

        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }

        public IResult Add(BrandForCreationDto brandForCreationDto)
        {       //Destination:Brand, Source:brandForCreationDto
            var brand = _mapper.Map<Brand>(brandForCreationDto); 
            _brandDal.Add(brand);
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

        public IDataResult<Brand> GetById(Guid BrandId)
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