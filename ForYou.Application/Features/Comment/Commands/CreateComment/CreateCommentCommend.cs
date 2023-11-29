using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Command.Commands.CreateComment
{
    public class CreateCommentCommend : IRequest<Guid>
    {
        public string Comment { get; set; }

        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
