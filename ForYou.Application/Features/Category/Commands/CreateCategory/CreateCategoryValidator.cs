using System;
using FluentValidation;
using ForYou.Application.Command.Post;
using ForYou.Application.Features.Category.Commands.CreateCategory;

namespace ForYou.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommend>
    {
        public CreateCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(100);
        }


    }
}