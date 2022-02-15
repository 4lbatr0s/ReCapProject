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
        IResult UploadImage(IFormFile file, CarImageForCreationDto carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetById(Guid carImageId);

        IResult Delete(Guid id);
        IResult Update(IFormFile file, CarImage carImage);

    }
}
