using ForYou.Domain.Entities;

namespace ForYou.Application.Services.Interfaces
{
    public interface IWebTokenService
    {
        public string GetToken(UserEntity user);
        string GenerateRefreshToken();
    }
}
