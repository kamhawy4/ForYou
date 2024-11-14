using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace ForYou.Application.Command.Post
{
    public class CreatePostCommend : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public List<Guid> TagIds { get; set; }
    }
}
