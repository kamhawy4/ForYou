using System;
using FluentValidation;

namespace ForYou.Application.Command.Commands.CreateComment
{
	public class CreateCommentValidator : AbstractValidator<CreateCommentCommend>
    {
	   public CreateCommentValidator()
        {
            RuleFor(p => p.Comment).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}

