using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Color:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorId { get; set;}
        public string ColorName { get; set;}
        public decimal Saturation { get; set;}
        public string HexadecimalValue { get; set; } 
    
    }
}
