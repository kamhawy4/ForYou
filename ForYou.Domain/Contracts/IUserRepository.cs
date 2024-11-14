using ForYou.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Domain.Contracts
{
    public interface IUserRepository<UserEntity>
    {
        Task<UserEntity> Login(UserEntity entity);

        Task<UserEntity> Reqister(UserEntity entity);

        Task<UserEntity> GetUserByEmail(string Email);

        Task<UserEntity> GetUserByRefreshTokenAsync(string Refreshhtoken);

        Task<UserEntity> AddAsync(UserEntity entity);

        void SaveRefreshToken(UserEntity entity, string Refreshhtoken);
    }
}
