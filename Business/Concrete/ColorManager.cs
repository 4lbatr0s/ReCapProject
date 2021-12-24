using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private readonly IColorDal _ColorDal;

        public void Add(Color Color)
        {
            _ColorDal.Add(Color);
        }

        public void Delete(Color Color)
        {
            _ColorDal.Delete(Color);
        }

        public List<Color> GetAll()
        {
            return _ColorDal.GetAll();
        }

        public Color GetById(int ColorId)
        {
            return _ColorDal.Get(Color => Color.ColorId == ColorId);
        }

        public void Update(Color Color)
        {
            _ColorDal.Update(Color);
        }
    }
}