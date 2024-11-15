﻿using ForYou.Application.Contracts;
using ForYou.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<CategoryEntity> categories {  get; }
        IAsyncRepository<PostEntity> posts { get; }
        IAsyncRepository<CommentEntity> comments { get; }
        IUserRepository<UserEntity> users { get; }
        IAsyncRepository<TagEntity> tags { get; }
     //   IAuditLogRepository<AuditLog> log { get; }

        int CommitChanges();
    }
}
