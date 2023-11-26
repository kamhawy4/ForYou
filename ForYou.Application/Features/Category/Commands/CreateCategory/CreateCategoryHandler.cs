using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Command.Post.CreatePost;
using ForYou.Application.Contracts;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Interfaces;
using MediatR;

namespace ForYou.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommend, Guid>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCategoryCommend request, CancellationToken cancellationToken)
        {
            CategoryEntity category =   _mapper.Map<CategoryEntity>(request);

            CreateCategoryValidator validator = new CreateCategoryValidator();

            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any()) throw new Exception("post not found");

            await _unitOfWork.categories.AddAsync(category);

            return category.Id;
        }
    }
}
