using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.Dto;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
        }

        public async Task<IResult> Add(User user)
        {
            await _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public async Task<IResult> Delete(User user)
        {
            await _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            return new SuccessDataResult<List<User>>(await _userDal.GetAll(), Messages.AllUsersListed);
        }

        public async Task<IDataResult<User>> GetById(Guid userId)
        {
            return new SuccessDataResult<User>( await _userDal.Get(u => u.Id == userId));
        }

        public async Task<IDataResult<User>> GetByMail(string mail)
        {
            return new SuccessDataResult<User>(await _userDal.Get(u => u.Email == mail));
        }

        public async Task<IDataResult<List<OperationClaim>>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(await _userDal.GetClaims(user));

        }

        public  async Task<IResult> Update(User user)
        {
            await _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

       
    }
}
