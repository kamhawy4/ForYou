using ForYou.Application.Features.Authentication.Login;
using ForYou.Application.Features.Authentication.RefreshToken;
using ForYou.Application.Features.Authentication.Register;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TResponse<LoginResponse>> LoginAsync(string email,string password);
        Task<bool> ADLoginAsync(string username, string password);
        
        Task<Guid> RegisterAsync(RegisterCommend request);

        Task<TResponse<RefreshTokenResponce>> GetRefreshToken(string Token, string refreshToken);

        bool ValidateUser(string username, string password);

        object GetUserDetails(string username);

    }
}
