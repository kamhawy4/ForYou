using ForYou.SharedServices.Models;
using MediatR;

namespace ForYou.Application.Features.Authentication.Login
{
    public class LoginCommend : IRequest<TResponse<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
