using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int BrandId);
        List<Brand> GetByCountry(string countrName);
        void Add(Brand Brand);
        void Delete(Brand Brand);
        void Update(Brand Brand);
    }
}
