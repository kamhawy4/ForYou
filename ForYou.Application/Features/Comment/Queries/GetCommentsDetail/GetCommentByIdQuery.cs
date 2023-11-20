using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Comment.Queries.GetCommentsDetail
{
    public class GetCommentByIdQuery :IRequest<GetCommentByIdQueryViewModel>
    {
        public Guid Id { get; set; }
    }
}
