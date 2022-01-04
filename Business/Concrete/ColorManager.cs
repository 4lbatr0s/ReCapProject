using Business.Abstract;
using Entities;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color Color)
        {
            _colorDal.Add(Color);
            return new SuccessResult(Messages.ColorAdded);
        }

       

        public IResult Delete(Color Color)
        {
            _colorDal.Delete(Color);
            return new SuccessResult(Messages.ColorDeleted);
        }

    

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.AllColorListed);
            
        }

        public IDataResult<List<Color>> GetByColorName(string name)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorName == name));
        }

        public IDataResult<Color> GetById(int ColorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(Color => Color.ColorId == ColorId));
        }

        

        public IResult Update(Color Color)
        {
            _colorDal.Update(Color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}