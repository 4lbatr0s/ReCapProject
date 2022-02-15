using Core.DataAccess;
using Entities;
using Entities.Dto;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car> //an interface is not public by default but it's functions are.
     {
        //this is where we do CRUD+ operations on the database. 
        List<CarDetailDto> GetCarDetails();
        List<CarForGetAllDto> GetCarsDto();
    }
}
