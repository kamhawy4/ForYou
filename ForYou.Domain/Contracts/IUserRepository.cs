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

        Task<UserEntity> GetUserByUsername(string Email);
    }
}
