using System;
namespace ForYou.Application.Interfaces
{
	public interface ICommentRepository
	{
		void AddComment(PostEntity postEntity);
	}
}

