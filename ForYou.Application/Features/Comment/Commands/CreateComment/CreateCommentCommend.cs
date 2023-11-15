using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Command.Post
{
    public class CreateCommentCommend : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
