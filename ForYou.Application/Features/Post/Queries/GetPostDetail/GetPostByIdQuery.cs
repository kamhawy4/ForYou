using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Post.Queries.GetPostDetail
{
    public class GetPostByIdQuery :  IRequest<GetPostByIdQueryViewModel>
    {
        public Guid Id { get; set; }
    }
}
