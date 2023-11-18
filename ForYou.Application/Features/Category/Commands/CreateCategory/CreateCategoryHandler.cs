using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Command.Post.CreatePost;
using ForYou.Application.Contracts;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Interfaces;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Interfaces;
using MediatR;

namespace ForYou.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommend, Guid>
    {
        private readonly IMapper _mapper;

        private readonly IGategoryRepository _gategoryRepository;

        public CreateCategoryHandler(IGategoryRepository gategoryRepository, IMapper mapper)
        {
            _gategoryRepository = gategoryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCategoryCommend request, CancellationToken cancellationToken)
        {
            CategoryEntity category =   _mapper.Map<CategoryEntity>(request);

            CreateCategoryValidator validator = new CreateCategoryValidator();

            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any()) throw new Exception("post not found");

            await _gategoryRepository.AddAsync(category);

            return category.Id;
        }
    }
}
