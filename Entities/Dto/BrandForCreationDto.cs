using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class BrandForCreationDto:IDto
    {
        public string BrandName { get; set; }
        public string BrandCountry { get; set; }
        public string Slogan { get; set; }
    }
}
