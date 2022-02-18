using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDBContext>, IRentalDal
    {
        public async Task<List<RentalDetailDto>> GetRentalDetails()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var allDetails = from r in context.Rentals
                                 join c in context.Cars
                                 on r.CarId equals c.CarId
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join cus in context.Customers
                                 on r.CustomerId equals cus.CustomerId
                                 join u in context.Users
                                 on cus.UserId equals u.Id
                                 select new RentalDetailDto
                                 {
                                     RentalId = r.RentalId,
                                     BrandName = b.BrandName,
                                     CustomerName = u.FirstName + " "+ u.LastName,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate
                                 };

                return await allDetails.ToListAsync();
            }
        }
    }
}
