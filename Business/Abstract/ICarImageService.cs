using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        Task<IResult> UploadImage(IFormFile file, CarImageForCreationDto carImage);
        Task<IDataResult<List<CarImage>>> GetAll();
        Task<IDataResult<List<CarImage>>> GetById(Guid carImageId);

        Task<IResult> Delete(CarImage carImage);
        Task<IResult> Update(IFormFile file, CarImage carImage);

    }
}
