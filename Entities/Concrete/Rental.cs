using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalId { get; set; }
        
        [ForeignKey("Car")]
        public int CarId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
