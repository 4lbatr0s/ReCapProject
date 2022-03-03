using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {

        public async Task<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
           
             using(ReCapDBContext context = new ReCapDBContext())
             {

                var allDetails = await (
                                  from c in filter is null ? context.Cars : context.Cars.Where(filter)
                                  join b in context.Brands
                                  on c.BrandId equals b.BrandId
                                  join col in context.Colors
                                  on c.ColorId equals col.ColorId
                                  select new CarDetailDto
                                  {
                                      CarId = c.CarId,
                                      BrandName = b.BrandName,
                                      ColorName = col.ColorName,
                                      DailyPrice = c.DailyPrice,
                                      Description = c.Description,
                                      ModelYear = c.ModelYear, 
                                      BrandId = c.BrandId,
                                      ColorId = c.ColorId,
                                      ImagePaths = (from Img in context.CarImages
                                                    where (c.CarId == Img.CarId)
                                                    select new CarImage
                                                    {
                                                        ImagePath = Img.ImagePath,
                                                        Date = Img.Date,
                                                        CarId = c.CarId,
                                                        CarImageId = Img.CarImageId
                                                    }).ToList()
                                  }).ToListAsync();

                return  allDetails; //return queryable to list.
             }
        }

    }
}
