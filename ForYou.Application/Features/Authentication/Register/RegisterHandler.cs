using AutoMapper;
using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using MediatR;

namespace ForYou.Application.Features.Authentication.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommend, Guid>
    {
        private readonly IAuthService _authService;

        public RegisterHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Guid> Handle(RegisterCommend request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterAsync(request);

        }
    }
}
