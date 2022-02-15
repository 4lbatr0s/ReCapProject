using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
           
             using(ReCapDBContext context = new ReCapDBContext())
             {
                 var allDetails=from c in context.Cars
                                join b in context.Brands
                                on c.BrandId equals b.BrandId
                                join col in context.Colors
                                on c.ColorId equals col.ColorId
                                select new CarDetailDto {
                                    Description = c.Description,
                                    BrandName = b.BrandName,
                                    ColorName = col.ColorName,
                                    DailyPrice = c.DailyPrice
                                };

                return allDetails.ToList(); //return queryable to list.
             }
        }

        public List<CarForGetAllDto> GetCarsDto()
        {
            using(ReCapDBContext context = new ReCapDBContext())
            {
                var allDetails = from car in context.Cars
                                 join brand in context.Brands
                                 on car.BrandId equals brand.BrandId
                                 join color in context.Colors
                                 on car.ColorId equals color.ColorId
                                 select new CarForGetAllDto
                                 {
                                     CarId = car.CarId,
                                     BrandName = brand.BrandName,
                                     ColorName = color.ColorName,
                                     DailyPrice = car.DailyPrice,
                                     Description = car.Description,
                                     ModelYear = car.ModelYear
                                 };
                return allDetails.ToList();
            }
            
        }
    }
}
