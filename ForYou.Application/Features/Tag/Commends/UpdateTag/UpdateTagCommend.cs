using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Tag.Commends.UpdateTag
{
    public class UpdateTagCommend : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
