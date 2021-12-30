using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
   public class CarDetailDto
    {
       
        //we are going to create a independent /no-inheritance focused
        //entity framework query just for this dto in the DataAccess layer for EfCarDal.
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
