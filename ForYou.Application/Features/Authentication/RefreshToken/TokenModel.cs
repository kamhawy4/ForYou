using ForYou.Application.Features.Authentication.Login;
using ForYou.SharedServices.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Authentication.RefreshToken
{
    public class TokenModel : IRequest<TResponse<RefreshTokenResponce>>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
