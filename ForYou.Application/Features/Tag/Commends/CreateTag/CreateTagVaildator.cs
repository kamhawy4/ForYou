using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Tag.Commends.CreateTag
{
    public class CreateTagVaildator : AbstractValidator<CreateTagCommend>
    {
        public CreateTagVaildator() {
            RuleFor(P => P.Title).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
