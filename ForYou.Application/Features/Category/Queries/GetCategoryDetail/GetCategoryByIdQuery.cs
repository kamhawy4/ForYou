using ForYou.Application.Features.Category.Queries.GetCategoryDetail;
using MediatR;


namespace ForYou.Application.Features.Category.Queries.GetCategoryDetail
{
    public class GetCategoryByIdQuery :IRequest<GetCategoryByIdQueryViewModel>
    {
        public Guid Id { get; set; }
    }
}
