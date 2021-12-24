using Entities.Abstract;

namespace Entities
{
    public class Color:IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set;}
        public decimal Saturation { get; set;}
        public string HexadecimalValue { get; set; } 
    
    }
}
