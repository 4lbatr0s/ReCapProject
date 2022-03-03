using Core.Entities;
using System;

namespace Entities.Dto
{
    public class CarImageForCreationDto:IDto
    {
        public Guid CarId { get; set; }

        public string  ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
