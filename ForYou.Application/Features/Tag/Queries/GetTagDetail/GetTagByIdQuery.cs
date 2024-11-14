using MediatR;

namespace ForYou.Application.Features.Tag.Queries.GetTagDetail
{
    public class GetTagByIdQuery : IRequest<GetTagByIdQueryViewModel>
    {
        public Guid Id { get; set; }
    }
}
