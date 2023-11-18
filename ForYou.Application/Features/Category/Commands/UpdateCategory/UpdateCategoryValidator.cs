using System;
using FluentValidation;
using ForYou.Application.Features.Category.Commands.CreateCategory;

namespace ForYou.Application.Command.Post.CreatePost
{
    public class UpdateCategoryValidator : AbstractValidator<CreateCategoryCommend>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(100);
        }

    }
}

