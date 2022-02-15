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
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(Guid carId);
        IDataResult<List<Car>> GetCarsByBrandId(Guid brandId);
        IDataResult<List<Car>> GetCarsByColorId(Guid colorId);
        IResult Add(CarForCreationDto car);
        IResult Delete(Guid carId);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
