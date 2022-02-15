using AutoMapper;
using Entities;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Automapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Source:BrandForCreationDto, Destination:Brand
            CreateMap<BrandForCreationDto, Brand>();
            CreateMap<CarForCreationDto, Car>();
            CreateMap<CarImageForCreationDto, CarImage>();
            CreateMap<CustomerCreationDto, Customer>();
            CreateMap<RentalForCreationDto, Rental>();
            CreateMap<ColorForCreationDto, Color>();
        }
    }
}
