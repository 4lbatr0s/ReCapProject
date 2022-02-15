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

        public IResult UploadImage(IFormFile file, CarImageForCreationDto carImageForCreationDto)
        {
            var carImage = _mapper.Map<CarImage>(carImageForCreationDto);
            var result = BusinessRules.Run(CheckIfCarImageNumberIsExceed(carImage.CarId)
               );
            if(result!= null)
            {   
                return result; //returns the business rule unfittings if there are any.
            } //it will return the error value, no need for a second call.
            carImage.ImagePath = Paths.ImagesPath + _fileHelper.Upload(file, Paths.ImagesPath); //_fileHelper.Upload() returns fileName therefore ImagePath equals (Paths.ImagesPath + fileName)
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageIsAdded);
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.AllCarImagesAreListed);
        }

        public IDataResult<List<CarImage>> GetById(Guid carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageNumberIsExceed(carId),
                CheckIfCarImageDoesExists(carId)
                );
            if(result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageNumberIsExceed(carImage.CarId)
              );
            if (result != null)
            {
                return result; //returns the business rule unfittings if there are any.
            }
            _fileHelper.Update(file, Paths.ImagesPath + carImage.ImagePath, Paths.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageIsUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageDoesExists(carImage.CarId)
                );
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carImage.CarId).Data);
            }
            _fileHelper.Delete(Paths.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
             return new SuccessResult(Messages.CarImageIsDeleted);
        }


        private IResult CheckIfCarImageNumberIsExceed(Guid carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImageCountIsExceeded);
            }
            return new SuccessResult(Messages.CarImageIsAdded);
        }

        private IDataResult<List<CarImage>> GetDefaultImage(Guid carId)        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "Default.jpg" });
            return new SuccessDataResult<List<CarImage>>();
        }

        private IResult CheckIfCarImageDoesExists(Guid carImageId)
        {
            var result = _carImageDal.Get(c => c.CarImageId == carImageId);
            if(result == null)
            {
                return new ErrorResult(Messages.CarImageDoesNotExist);
            }
            return new SuccessResult(Messages.CarImageDoesExists);
        }
    }
}
