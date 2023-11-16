using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Command.Post
{
    public class DeletePostCommend : IRequest
    {
        public Guid Id { get; set; }
    }
}
