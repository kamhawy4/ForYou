using ForYou.Application.Contracts;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository<UserEntity> , IAsyncRepository<UserEntity>
    {

        protected readonly PostDbContext _dbContext;

        public UserRepository(PostDbContext dbContext) : base(dbContext) {

            _dbContext = dbContext;

        }

        public Task<UserEntity> Login(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Reqister(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
          return await  _dbContext.Users.FirstOrDefaultAsync(_=>_.Email == email);
        }


        public async Task<UserEntity> GetUserByRefreshTokenAsync(string refreshToken)
        {
            // Query the user based on the refresh token
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken && u.RefreshTokenExpiryTime > DateTime.Now);
        }

        public void SaveRefreshToken(UserEntity user, string refreshToken)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _dbContext.SaveChanges();
        }
    }
}
