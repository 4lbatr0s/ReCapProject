//using AutoMapper;
//using Core.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Core.Utilities.Mapper
//{
   
//    public class MappingHelper<TDto, TEntity>:IMapHelper<TDto, TEntity>
//        where TDto: class, IDto, new()
//        where TEntity: class, IEntity, new()
//    {
//        private readonly IMapper _mapper;

//        public MappingHelper(IMapper mapper)
//        {
//            _mapper = mapper;
//        }

//        public TEntity Map(TDto dto, TEntity entity)
//        {
//            return _mapper.Map<typeof(entity)>()
//        }
//    }
//}
