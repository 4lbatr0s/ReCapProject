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
        public IResult Add(CarForCreationDto carForCreationDto)
        {
            var car = _mapper.Map<Car>(carForCreationDto);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        //[SecuredOperation("admin")]
        //[CacheRemoveAspect("ICarService.Get")] //remove all cache that include the "Get" keyword, Get, GetAll,GetById etc..
        public IResult Delete(Guid carId)
        {
            var result = _carDal.Get(c => c.CarId == carId);
            if(result is null)
            {
                return new ErrorResult(Messages.CarDoesNotExist);
            }
            else
            {
                _carDal.Delete(result);
                return new SuccessResult(Messages.CarDeleted);
            }
           
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.AllCarListed);
        }


        public IDataResult<Car> GetById(Guid carId)
        {
            //here, we create our filters to send EfCarDal functions, hence to the IEntityRepository Generic Repository Pattern.
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetails);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(Guid brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(Guid colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")] //remove all cache that include the "Get" keyword, Get, GetAll,GetById etc..
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

       
    }
}
