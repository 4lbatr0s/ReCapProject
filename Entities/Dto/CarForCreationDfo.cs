using Core.Entities;
using System;

namespace Entities.Dto
{
    public class CarForCreationDto : IDto
    {
        public Guid BrandId { get; set; }

        public Guid ColorId { get; set; }

        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
