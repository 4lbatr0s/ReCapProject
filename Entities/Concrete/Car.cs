using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Car:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Color")]
        public int ColorId { get; set; }

        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set;}

    }
}
