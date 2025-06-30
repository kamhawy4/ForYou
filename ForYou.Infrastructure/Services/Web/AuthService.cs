using AutoMapper;
using ForYou.Application.Common.Helpers;
using ForYou.Application.Features.Authentication.Login;
using ForYou.Application.Features.Authentication.RefreshToken;
using ForYou.Application.Features.Authentication.Register;
using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.DirectoryServices.AccountManagement;

namespace ForYou.Infrastructure.Services.Web
{
    public class AuthService : IAuthService
    {
        private readonly ActiveDirectorySettings _adService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebTokenService _webTokenService;
        private readonly string _domainName;
        private readonly string _container;

        public AuthService(IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork, IWebTokenService webTokenService, IOptions<ActiveDirectorySettings> adSettings)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webTokenService = webTokenService;
            _domainName = adSettings.Value.Domain;
            _container = adSettings.Value.Container;
        }


        public async Task<TResponse<LoginResponse>> LoginAsync(string email, string password)
        {
            var user = await _unitOfWork.users.GetUserByEmail(email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.password))
                throw new Exception("Invalid credentials");

            var generateRefresh = _webTokenService.GenerateRefreshToken();

            _unitOfWork.users.SaveRefreshToken(user, generateRefresh);

            var loginResult = user.MappToLogin(_webTokenService.GetToken(user));

            return TResponse<LoginResponse>.Success(loginResult);
        }


        public async Task<Guid> RegisterAsync(RegisterCommend request)
        {

            UserEntity user = _mapper.Map<UserEntity>(request);

            RegisterValidator validator = new RegisterValidator();

            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any()) throw new Exception("there something wrong");

            user.password = BCrypt.Net.BCrypt.HashPassword(request.password);

            await _unitOfWork.users.AddAsync(user);

            return user.Id;
        }

        public async Task<TResponse<RefreshTokenResponce>> GetRefreshToken(string Token, string refreshToken)
        {
            // Validate the old refresh token
            var user = await _unitOfWork.users.GetUserByRefreshTokenAsync(refreshToken);
            if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new Exception("Invalid or expired refresh token");
            }

            // Generate a new access token and refresh token
            var newJwtToken = _webTokenService.GetToken(user);
            var newRefreshToken = _webTokenService.GenerateRefreshToken();

            // Update refresh token
            _unitOfWork.users.SaveRefreshToken(user, newRefreshToken);

            return TResponse<RefreshTokenResponce>.Success(new RefreshTokenResponce()
            {
                RefreshToken = newRefreshToken,
                Token = newJwtToken,
            });

        }

        public bool ValidateUser(string username, string password)
        {
            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, _domainName, _container))
                {
                    // Validate the user credentials
                    return context.ValidateCredentials(username, password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating user: {ex.Message}");
                return false;
            }
        }

        public object GetUserDetails(string username)
        {
            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, _domainName, _container))
                {

                    using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                    {
                        var user = searcher.FindOne() as UserPrincipal;
                        return user;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating user: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> ADLoginAsync(string username, string password)
        {
            try
            {
                using (var context =  new PrincipalContext(ContextType.Domain, _domainName, _container))
                {
                    return  context.ValidateCredentials(username, password);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating user: {ex.Message}");
                return false;
            }
        }
    }
}
