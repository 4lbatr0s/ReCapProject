using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        Task<IDataResult<List<Car>>> GetAll();
        Task<IDataResult<Car>> GetById(Guid carId);
        Task<IDataResult<List<Car>>> GetCarsByBrandId(Guid brandId);
        Task<IDataResult<List<Car>>> GetCarsByColorId(Guid colorId);
        Task<IResult> Add(CarForCreationDto car);
        Task<IResult> Delete(Car car);
        Task<IResult> Update(Car car);
        Task<IDataResult<List<CarDetailDto>>> GetCarDetails();
    }
}
