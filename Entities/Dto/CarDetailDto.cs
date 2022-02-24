using System;

namespace Entities.Dto
{
   public class CarDetailDto
    {

        //we are going to create a independent /no-inheritance focused
        //entity framework query just for this dto in the DataAccess layer for EfCarDal.
        public Guid CarId { get; set; }

        public string BrandName { get; set; }

        public string ImagePath { get; set; }

        public string ColorName { get; set; }

        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
