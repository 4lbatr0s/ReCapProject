using Core.Utilities.Results;
using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int ColorId);
        IResult Add(Color Color);
        IResult Delete(Color Color);
        IResult Update(Color Color);
        IDataResult<List<Color>> GetByColorName(string name);
        
    }
}
