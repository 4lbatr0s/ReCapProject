using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private readonly IBrandDal _brandDal;

        public void Add(Brand Brand)
        {
            _brandDal.Add(Brand);
        }

        public void Delete(Brand Brand)
        {
            _brandDal.Delete(Brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetByCountry(string countrName)
        {
            return _brandDal.GetAll(brand => brand.BrandCountry == countrName);
        }

        public Brand GetById(int BrandId)
        {
            return _brandDal.Get(brand => brand.BrandId == BrandId);
        }

        public void Update(Brand Brand)
        {
            _brandDal.Update(Brand);
        }
    }
}