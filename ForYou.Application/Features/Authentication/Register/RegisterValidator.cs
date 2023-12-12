using System;
using FluentValidation;
using ForYou.Application.Command.Post;
using ForYou.Application.Features.Category.Commands.CreateCategory;

namespace ForYou.Application.Features.Authentication.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommend>
    {
        public RegisterValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(100);
        }

    }
}