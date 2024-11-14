using FluentValidation;
using ForYou.Application.Features.Tag.Commends.UpdateTag;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Tag.Commends.UpdateTag
{
    public class UpdateTagVaildator : AbstractValidator<UpdateTagCommend>
    {
        public UpdateTagVaildator()
        {
            RuleFor(p => p.Title).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
