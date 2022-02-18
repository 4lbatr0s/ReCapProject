using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        Task<IDataResult<List<Color>>> GetAll();
        Task<IDataResult<Color>> GetById(Guid ColorId);
        Task<IResult> Add(ColorForCreationDto Color);
        Task<IResult> Delete(Color color);
        Task<IResult> Update(Color Color);
        Task<IDataResult<List<Color>>> GetByColorName(string name);
        
    }
}
