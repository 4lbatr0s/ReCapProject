using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        public async Task<List<CarDetailDto>> GetCarDetails()
        {
           
             using(ReCapDBContext context = new ReCapDBContext())
             {
                 var allDetails=from c in context.Cars
                                join b in context.Brands
                                on c.BrandId equals b.BrandId
                                join col in context.Colors
                                on c.ColorId equals col.ColorId
                                select new CarDetailDto {
                                    CarId = c.CarId,
                                    BrandName = b.BrandName,
                                    ColorName = col.ColorName,
                                    DailyPrice = c.DailyPrice,
                                    Description = c.Description,
                                    ModelYear = c.ModelYear
                                };

                return await allDetails.ToListAsync(); //return queryable to list.
             }
        }

    }
}
