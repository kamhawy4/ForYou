using AutoMapper;
using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.SharedServices.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ForYou.Application.Features.Authentication.Login
{
    public class ADLoginHandler : IRequestHandler<ADLoginCommend, bool>
    {
        private readonly IAuthService _authService;

        public ADLoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(ADLoginCommend request, CancellationToken cancellationToken)
        {
            return await _authService.ADLoginAsync(request.username, request.Password);
        }

    }
}
