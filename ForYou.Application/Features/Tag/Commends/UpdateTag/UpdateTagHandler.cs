using AutoMapper;
using FluentValidation;
using ForYou.Application.Command.Post;
using ForYou.Application.Features.Tag.Commends.CreateTag;
using ForYou.Application.Features.Tag.Commends.UpdateTag;
using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Tag.Commends.UpdateTag
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommend>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTagHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task Handle(UpdateTagCommend request, CancellationToken cancellationToken)
        {

            UpdateTagVaildator vaildator = new UpdateTagVaildator();

            var result = await vaildator.ValidateAsync(request);

            if (result.Errors.Any()) throw new Exception("all input is requierd");

            var tag = await _unitOfWork.tags.GetByIdAsync(request.Id);

            tag.Title = request.Title;

            await _unitOfWork.tags.UpdateAsync(tag);

        }
    }
}
