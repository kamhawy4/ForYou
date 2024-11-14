using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Command.Post.CreatePost;
using ForYou.Application.Common.Models;
using ForYou.Application.Contracts;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Interfaces;
using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;

namespace ForYou.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommend, Result<string>>
    {
        private readonly IMapper _mapper;
        private readonly string _userId; // Assume you get the userId from the user context or JWT token
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogger _auditLogger;
        private readonly IStringLocalizer _Localizer;

        private readonly IStringLocalizer<CreateCategoryHandler> _localizer;


        public CreateCategoryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAuditLogger auditLogger, IStringLocalizer<CreateCategoryHandler> localizer)
        {
            _mapper = mapper;
            _auditLogger = auditLogger;
            _userId = "421610c0-76a9-45c3-b0e7-3f4fed5fc7d2";
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(CreateCategoryCommend request, CancellationToken cancellationToken)
        {
            CategoryEntity category =   _mapper.Map<CategoryEntity>(request);

            CreateCategoryValidator validator = new CreateCategoryValidator();

            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
                return Result<string>.Failure("something error");

            await _unitOfWork.categories.AddAsync(category);

            await _auditLogger.LogAsync("Performed an action", _userId, "Additional action details");

            return Result<string>.Success(_localizer["categorysuccess"]);
        }
    }
}
