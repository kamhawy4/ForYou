using ForYou.SharedServices.Models;
using MediatR;

namespace ForYou.Application.Features.Tag.Queries.GetTagList
{
    public class GetTagListQuery : IRequest<TResponse<List<GetTagListQueryViewModel>>>
    {

    }
}
