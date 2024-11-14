using MediatR;

namespace ForYou.Application.Features.Authentication.Register
{
    public class RegisterCommend : IRequest<Guid>
    {

        public string UserName { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string password { get; set; }
        public string Email { get; set; } 
        public string Mobile { get; set; }


    }
}
