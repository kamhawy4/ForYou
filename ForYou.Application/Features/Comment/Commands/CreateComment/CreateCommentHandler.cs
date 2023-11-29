using AutoMapper;
using FluentValidation;
using ForYou.Application.Command.Commands.CreateComment;
using ForYou.Application.Command.Post;
using ForYou.Application.Contracts;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Handler.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommend, Guid>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCommentCommend request, CancellationToken cancellationToken)
        {
            CommentEntity comments = _mapper.Map<CommentEntity>(request);

            CreateCommentValidator validator = new CreateCommentValidator();

            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any()) throw new Exception("comment not found");

            await _unitOfWork.comments.AddAsync(comments);

            return comments.Id;

        }


    }
}
