using Core.Entities.Concrete;
using Core.Results;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDTO userForLoginDTO);

        IResult UserAlreadyExists(string email);

        IDataResult<User> Register(UserForRegisterDTO userForRegisterDTO);

        public IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
