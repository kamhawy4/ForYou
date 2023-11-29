using MediatR;
using System;

namespace ForYou.Application.Command.Post
{
    public class CreatePostCommend : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
