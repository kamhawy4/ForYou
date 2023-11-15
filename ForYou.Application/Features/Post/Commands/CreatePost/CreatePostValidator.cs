using FluentValidation;
using System;
namespace ForYou.Application.Command.Post
{
	public class CreatePostValidator : AbstractValidator<CreatePostCommend>
    {
	   public CreatePostValidator() {

			RuleFor(p => p.Title).NotEmpty().NotNull().MaximumLength(100);
			RuleFor(p => p.Content).NotEmpty().NotNull().MaximumLength(500);
		}
	}
}

