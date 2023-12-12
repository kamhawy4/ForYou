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

namespace ForYou.Application.Features.Authentication.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommend, Guid>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public RegisterHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegisterCommend request, CancellationToken cancellationToken)
        {
            CategoryEntity category =   _mapper.Map<CategoryEntity>(request);

            RegisterValidator validator = new RegisterValidator();

            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any()) throw new Exception("post not found");

            await _unitOfWork.categories.AddAsync(category);

            return category.Id;
        }
    }
}
