using ForYou.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Authentication.Login
{
    public static class LoginMapping
    {
        public static LoginResponse MappToLogin(this UserEntity user, string token)
        {
            return new LoginResponse()
            {
                Email = user.Email,
                Token = token,
            };
        }
    }
}
