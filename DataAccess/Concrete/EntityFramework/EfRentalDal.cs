using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDBContext>, IRentalDal
    {
        public List<RentalForGetAllDto> GetRentalsDto()
        {
            //using (ReCapDBContext context = new ReCapDBContext())
            //{
            //    var allDetails = from rental in context.Rentals
            //                     join brand in context.Brands
            //                     on car.BrandId equals brand.BrandId
            //                     join color in context.Colors
            //                     on car.ColorId equals color.ColorId
            //                     select new CarForGetAllDto
            //                     {
            //                         CarId = car.CarId,
            //                         BrandName = brand.BrandName,
            //                         ColorName = color.ColorName,
            //                         DailyPrice = car.DailyPrice,
            //                         Description = car.Description,
            //                         ModelYear = car.ModelYear
            //                     };
            //    return allDetails.ToList();
            //}
            return null;
        }
    }
}
