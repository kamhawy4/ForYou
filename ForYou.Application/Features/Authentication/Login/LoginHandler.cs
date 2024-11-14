using AutoMapper;
using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.SharedServices.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ForYou.Application.Features.Authentication.Login
{
    public class LoginHandler : IRequestHandler<LoginCommend, TResponse<LoginResponse>>
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<TResponse<LoginResponse>> Handle(LoginCommend request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request.Email, request.Password);
        }

    }
}
