using ForYou.Application.Services.Interfaces;
using ForYou.SharedServices.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Authentication.RefreshToken
{
    public class GetRefreshToken : IRequestHandler<TokenModel, TResponse<RefreshTokenResponce>>
    {

        private readonly IAuthService _authService;

        public GetRefreshToken(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TResponse<RefreshTokenResponce>> Handle(TokenModel request, CancellationToken cancellationToken)
        {
            return await _authService.GetRefreshToken(request.Token, request.RefreshToken);
        }
    }
}
