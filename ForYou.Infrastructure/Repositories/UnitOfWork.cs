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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostDbContext _context;
        public UnitOfWork(PostDbContext context) {

            _context = context;
            categories = new BaseRepository<CategoryEntity>(_context);
            posts = new BaseRepository<PostEntity>(_context);
            comments = new BaseRepository<CommentEntity>(_context);

            users = new UserRepository(_context);

        }

        public IAsyncRepository<CategoryEntity> categories  { get; private set; }

        public IAsyncRepository<PostEntity> posts { get; private set; }

        public IAsyncRepository<CommentEntity> comments { get; private set; }

        public IUserRepository<UserEntity> users { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
