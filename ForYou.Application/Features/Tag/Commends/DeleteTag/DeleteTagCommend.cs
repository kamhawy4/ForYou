using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Tag.Commends.DeleteTag
{
    public class DeleteTagCommend : IRequest
    {
        public Guid Id { get; set; }
    }
}
