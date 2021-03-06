using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Dto;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt; //Core/Utilities/Encryption/Hashing/HashingHelper.CreatePassword
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true //active user.
            };
            await _userService.Add(user); //add user to the database.
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public async  Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {

            var userToCheck = await _userService.GetByMail(userForLoginDto.Email); //fetch user by email.
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!(HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt)))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public async Task<IResult> UserExists(string email)
        {
            var result = await _userService.GetByMail(email);
            if (result is not null)
            {
                return  new SuccessResult();
            }
            return  new ErrorResult(Messages.UserAlreadyExists);
        }


        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {   
            var claims = await _userService.GetClaims(user);
            var accessToken =  _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
 
    }
}