using Core.Entities;

namespace Entities
{
    public class Brand:IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandCountry { get; set; }
        public string Slogan { get; set; }
    }
}
