using ForYou.SharedServices.Models;
using MediatR;

namespace ForYou.Application.Features.Authentication.Login
{
    public class ADLoginCommend : IRequest<bool>
    {
        public string username { get; set; }
        public string Password { get; set; }
    }
}
