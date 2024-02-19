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
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        // private readonly IAuthenticatService _authenticatService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebTokenService _webTokenService;

        public LoginHandler(IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork, IWebTokenService webTokenService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webTokenService = webTokenService;
        }

        public async Task<TResponse<LoginResponse>> Handle(LoginCommend request, CancellationToken cancellationToken)
        {
            //var checkUser = await _authenticatService.IsAuthenticated(request.Email, request.Password);

            try
            {
                var user = await _unitOfWork.users.GetUserByEmail(request.Email);

                var loginResult = user.MappToLogin(_webTokenService.GetToken(user));

                return TResponse<LoginResponse>.Success(loginResult);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
