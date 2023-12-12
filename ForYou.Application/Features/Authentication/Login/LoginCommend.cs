using MediatR;

namespace ForYou.Application.Features.Authentication.Login
{
    public class LoginCommend : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
