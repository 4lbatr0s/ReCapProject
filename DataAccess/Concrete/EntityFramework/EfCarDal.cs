using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        //CarName, BrandName, ColorName, DailyPrice.
        public List<CarDetailDto> GetCarDetails()
        {
            //first we have to reach database in order to fetch our joined data.
            using(ReCapDBContext context = new ReCapDBContext())
            {
                var detailedQuery = from car in context.Cars
                                    join b in context.Brands
                                    on car.BrandId equals b.BrandId
                                    join col in context.Colors
                                    on car.ColorId equals col.ColorId
                                    select new CarDetailDto
                                    {
                                        Description = car.Description,
                                        BrandName = b.BrandName,
                                        ColorName = col.ColorName,
                                        DailyPrice = car.DailyPrice
                                    };
                return detailedQuery.ToList();
            }
        }
    }
}
