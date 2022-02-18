using Business.Abstract;
using Entities;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;
using System;
using Entities.Dto;
using AutoMapper;
using System.Threading.Tasks;

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

        public async Task<IResult> Add(ColorForCreationDto colorForCreationDto)
        {
            var color = _mapper.Map<Color>(colorForCreationDto);
            await _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

       

        public async Task<IResult> Delete(Color color)
        {
            await _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

    

        public async Task<IDataResult<List<Color>>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(await _colorDal.GetAll(), Messages.AllColorListed);
            
        }

        public async Task<IDataResult<List<Color>>>  GetByColorName(string name)
        {
            return new SuccessDataResult<List<Color>>(await _colorDal.GetAll(c => c.ColorName == name));
        }

        public async Task<IDataResult<Color>> GetById(Guid ColorId)
        {
            return new SuccessDataResult<Color>(await _colorDal.Get(Color => Color.ColorId == ColorId));
        }

        

        public async Task<IResult> Update(Color Color)
        {
            await _colorDal.Update(Color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}