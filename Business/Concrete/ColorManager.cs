using Business.Abstract;
using Entities;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;
using System;
using Entities.Dto;
using AutoMapper;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private readonly IColorDal _colorDal;
        private readonly IMapper _mapper;
        public ColorManager(IColorDal colorDal, IMapper mapper)
        {
            _colorDal = colorDal;
            _mapper = mapper;
        }

        public IResult Add(ColorForCreationDto colorForCreationDto)
        {
            var color = _mapper.Map<Color>(colorForCreationDto);
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

       

        public IResult Delete(Guid id)
        {
            var result = _colorDal.Get(c => c.ColorId == id);
            _colorDal.Delete(result);
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

        public IDataResult<Color> GetById(Guid ColorId)
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