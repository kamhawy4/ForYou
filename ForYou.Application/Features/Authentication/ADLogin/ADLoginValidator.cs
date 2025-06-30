using System;
using FluentValidation;
using ForYou.Application.Command.Post;
using ForYou.Application.Features.Category.Commands.CreateCategory;

namespace ForYou.Application.Features.Authentication.Login
{
    public class ADLoginValidator : AbstractValidator<LoginCommend>
    {
        public ADLoginValidator()
        {
            RuleFor(p => p.Email).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(p => p.Password).NotEmpty().NotNull().MaximumLength(100);
        }

    }
}