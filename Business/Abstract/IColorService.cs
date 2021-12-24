using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int ColorId);
        void Add(Color Color);
        void Delete(Color Color);
        void Update(Color Color);
        
        List<Color> GetByColorName(string name);
        
    }
}
