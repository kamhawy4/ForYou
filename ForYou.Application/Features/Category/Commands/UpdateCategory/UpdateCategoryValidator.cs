using System;
using FluentValidation;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Features.Category.Commands.UpdateCategory;

namespace ForYou.Application.Command.Post.CreatePost
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommend>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(100);
        }

    }
}

