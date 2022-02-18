using Core.Entities.Concrete.Dto;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetAll();
        Task<IDataResult<User>> GetById(Guid userId);
        Task<IDataResult<User>> GetByMail(string mail);
        Task<IResult> Add(User user);
        Task<IResult> Update(User user);
        Task<IResult> Delete(User user);
        Task<IDataResult<List<OperationClaim>>> GetClaims(User user);
    }
}
