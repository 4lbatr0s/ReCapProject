using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage : IEntity //no naked class principle.
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarImageId { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        
    }
}
