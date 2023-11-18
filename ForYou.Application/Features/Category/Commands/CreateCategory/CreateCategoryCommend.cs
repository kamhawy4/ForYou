using MediatR;

namespace ForYou.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommend : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
