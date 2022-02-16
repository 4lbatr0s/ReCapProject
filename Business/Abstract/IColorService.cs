using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(Guid ColorId);
        IResult Add(ColorForCreationDto Color);
        IResult Delete(Color color);
        IResult Update(Color Color);
        IDataResult<List<Color>> GetByColorName(string name);
        
    }
}
