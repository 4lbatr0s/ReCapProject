using Core.Entities;

namespace Entities.Dto
{
    public class ColorForCreationDto : IDto
    {
        public string ColorName { get; set; }
        public decimal Saturation { get; set; }
        public string HexadecimalValue { get; set; }

    }
}
