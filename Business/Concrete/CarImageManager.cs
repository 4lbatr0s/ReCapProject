using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;
        private readonly IMapper _mapper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper, IMapper mapper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
            _mapper = mapper;
        }

        public async Task<IResult> UploadImage(IFormFile file, CarImageForCreationDto carImageForCreationDto)
        {
            var carImage = _mapper.Map<CarImage>(carImageForCreationDto);
            var result = BusinessRules.Run(CheckIfCarImageNumberIsExceed(carImage.CarId).Result
               );
            if(result is not null)
            {   
                return result; //returns the business rule unfittings if there are any.
            } //it will return the error value, no need for a second call.
            carImage.ImagePath = Paths.ImagesPath + _fileHelper.Upload(file, Paths.ImagesPath); //_fileHelper.Upload() returns fileName therefore ImagePath equals (Paths.ImagesPath + fileName)
            carImage.Date = DateTime.Now;
            await _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageIsAdded);
        }


        public async Task<IDataResult<List<CarImage>>> GetAll()
        {
            var result = await _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result, Messages.AllCarImagesAreListed);
        }

        public async Task<IDataResult<List<CarImage>>> GetById(Guid carId)
        {
            var result =  BusinessRules.Run(CheckIfCarImageNumberIsExceed(carId).Result,
                CheckIfCarImageDoesExists(carId).Result
                );
            if(result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Result.Data);
            }
            return new SuccessDataResult<List<CarImage>>(await _carImageDal.GetAll(c => c.CarId == carId));
        }

        public async Task<IResult> Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageNumberIsExceed(carImage.CarId).Result
              );
            if (result is not null)
            {
                return result; //returns the business rule unfittings if there are any.
            }
            _fileHelper.Update(file, Paths.ImagesPath + carImage.ImagePath, Paths.ImagesPath);
            await _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageIsUpdated);
        }

        public async Task<IResult> Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageDoesExists(carImage.CarId).Result
                );
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carImage.CarId).Result.Data);
            }
             _fileHelper.Delete(Paths.ImagesPath + carImage.ImagePath);
            await _carImageDal.Delete(carImage);
             return new SuccessResult(Messages.CarImageIsDeleted);
        }


        private async Task<IResult> CheckIfCarImageNumberIsExceed(Guid carId)
        {
            var result = await _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count>=5)
            {
                return new ErrorResult(Messages.CarImageCountIsExceeded);
            }
            return new SuccessResult(Messages.CarImageIsAdded);
        }

        private async Task<IDataResult<List<CarImage>>> GetDefaultImage(Guid carId)
        { 
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "Default.jpg" });
            await Task.Delay(1000);
            return new SuccessDataResult<List<CarImage>>();
        }

        private async Task<IResult> CheckIfCarImageDoesExists(Guid carImageId)
        {
            var result = await _carImageDal.Get(c => c.CarImageId == carImageId);
            if(result is null)
            {
                return new ErrorResult(Messages.CarImageDoesNotExist);
            }
            return new SuccessResult(Messages.CarImageDoesExists);
        }
    }
}
