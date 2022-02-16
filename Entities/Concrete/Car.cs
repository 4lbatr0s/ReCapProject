using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Car:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CarId { get; set; }

        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }
        public Brand Brand; 

        [ForeignKey("Color")]
        public Guid ColorId { get; set; }
        public Color Color { get; set; }

        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set;}

    }
}
