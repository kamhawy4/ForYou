using ForYou.Domain.Entities;
using System;
namespace ForYou.Application.Contracts
{
	public interface ICommentRepository : IAsyncRepository<CommentEntity>
    {

	}
}

