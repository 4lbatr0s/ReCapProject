using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using System.Linq.Expressions;
using Entities.Dto;
using Core.Utilities.Results;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using AutoMapper;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        public CarManager(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        //[SecuredOperation("admin")]
        //[ValidationAspect (typeof(CarValidator))] //throw exception if request body does not fill the requirements.
        //[CacheRemoveAspect("ICarService.Get")] //remove all cache that include the "Get" keyword, Get, GetAll,GetById etc..
        public async Task<IResult> Add(CarForCreationDto carForCreationDto)
        {
            var car = _mapper.Map<Car>(carForCreationDto);
            await _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAspect("ICarService.Get")] //remove all cache that include the "Get" keyword, Get, GetAll,GetById etc..
        public async Task<IResult> Delete(Car car)
        {
            if(car is null)
            {
                return new ErrorResult(Messages.CarDoesNotExist);
            }
            else
            {
                await _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
           
        }


        [CacheAspect]
        public async Task<IDataResult<List<Car>>> GetAll()
        {
            var result = await _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result, Messages.AllCarListed);
        }


        public async Task<IDataResult<Car>> GetById(Guid carId)
        {
            //here, we create our filters to send EfCarDal functions, hence to the IEntityRepository Generic Repository Pattern.
            return new SuccessDataResult<Car>(await _carDal.Get(p => p.CarId == carId));
        }

        public async Task<IDataResult<List<CarDetailDto>>> GetCarDetails()
        {
            var result = await _carDal.GetCarDetails();
          
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarDetails);
        }

        public async Task<IDataResult<List<CarDetailDto>>> GetCarDetailsByColorId(Guid colorId)
        {
            var result  = await _carDal.GetCarDetails(c => c.ColorId == colorId);

            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarDetails);
        }

        public async Task<IDataResult<List<CarDetailDto>>> GetCarDetailsByBrandId(Guid brandId)
        {
            var result = await _carDal.GetCarDetails(c => c.BrandId == brandId);

            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarDetails);
        }

        public async Task<IDataResult<CarDetailDto>> GetCarDetailsById(Guid carId)
        {
            var cars = await _carDal.GetCarDetails();
            var result = cars.Where(c => c.CarId == carId).SingleOrDefault();

            return new SuccessDataResult<CarDetailDto>(result, Messages.CarDetails);
        }

        public async Task<IDataResult<List<Car>>> GetCarsByBrandId(Guid brandId)
        {
            return new SuccessDataResult<List<Car>>(await _carDal.GetAll(c => c.BrandId == brandId));
        }



        public async Task<IDataResult<List<Car>>> GetCarsByColorId(Guid colorId)
        {
            return new SuccessDataResult<List<Car>>(await _carDal.GetAll(c => c.ColorId == colorId));
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")] //remove all cache that include the "Get" keyword, Get, GetAll,GetById etc..
        public async Task<IResult> Update(Car car)
        {
            await _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

      
    }
}
