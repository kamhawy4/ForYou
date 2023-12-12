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
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository<UserEntity>
    {
        public UserRepository( PostDbContext dbContext) : base(dbContext) { }

         protected readonly PostDbContext _dbContext;

        public Task<UserEntity> Login(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Reqister(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetUserByUsername(string username)
        {
          return await  _dbContext.Users.FirstOrDefaultAsync(_=>_.UserName == username);
        }
    }
}
