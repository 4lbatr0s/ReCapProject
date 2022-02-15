using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class CustomerCreationDto:IDto
    {
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
