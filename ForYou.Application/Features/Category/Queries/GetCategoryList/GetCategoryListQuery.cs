using ForYou.SharedServices.Models;
using MediatR;

namespace ForYou.Application.Features.Category.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<TResponse<List<GetCategoryListQueryViewModel>>>
    {

    }
}
