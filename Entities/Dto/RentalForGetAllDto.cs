using Core.Entities;
using System;

namespace Entities.Dto
{
    public class RentalForGetAllDto:IDto
    {
       
        public Guid RentalId { get; set; }

        public string BrandName { get; set; }

        public string CustomerName { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
