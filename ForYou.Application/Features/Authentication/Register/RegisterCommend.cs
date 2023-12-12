using MediatR;

namespace ForYou.Application.Features.Authentication.Register
{
    public class RegisterCommend : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
