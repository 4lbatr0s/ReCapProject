using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;
using AutoMapper;
using Entities.Dto;
using System.Threading.Tasks;

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

        public async Task<IResult> Add(BrandForCreationDto brandForCreationDto)
        {       //Destination:Brand, Source:brandForCreationDto
            var brand = _mapper.Map<Brand>(brandForCreationDto); 
            await _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public async Task<IResult> Delete(Brand brand)
        {
            await _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public async Task<IDataResult<List<Brand>>> GetAll()
        {
            var result = await _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result, Messages.AllBrandsListed);
        }

        public async Task<IDataResult<List<Brand>>> GetByCountry(string countrName)
        {
            var result = await _brandDal.GetAll(c => c.BrandCountry == countrName));
            return new SuccessDataResult<List<Brand>>(result);
        }

        public async Task<IDataResult<Brand>> GetById(Guid BrandId)
        {
            var result = await _brandDal.Get(brand => brand.BrandId == BrandId);
            return new SuccessDataResult<Brand>(result);
        }



        public async Task<IResult> Update(Brand Brand)
        {    
            await _brandDal.Update(Brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}