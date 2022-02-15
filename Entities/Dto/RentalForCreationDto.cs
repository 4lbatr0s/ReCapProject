using Core.Entities;
using System;

namespace Entities.Dto
{
    public class RentalForCreationDto:IDto
    {
        public Guid CarId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
