using ForYou.Application.Features.Post.Queries.GetPostDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Post.Queries.GetPostsList
{
    public class GetPostListQuery : IRequest<List<GetPostListQueryViewModel>>
    {

    }
}
