using Core.DataAccess;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car> //an interface is not public by default but it's functions are.
     {
        //this is where we do CRUD+ operations on the database. 
        Task<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);
    }
}
