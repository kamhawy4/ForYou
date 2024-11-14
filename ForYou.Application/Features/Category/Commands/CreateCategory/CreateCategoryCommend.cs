using ForYou.Application.Common.Models;
using MediatR;

namespace ForYou.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommend : IRequest<Result<string>>
    {
        public string Name { get; set; }
    }
}
