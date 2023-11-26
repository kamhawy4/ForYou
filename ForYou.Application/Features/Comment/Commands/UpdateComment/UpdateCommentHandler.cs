using AutoMapper;
using ForYou.Application.Command.Commands.UpdateComment;
using ForYou.Application.Command.Post;
using ForYou.Application.Contracts;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Handler.Commands.UpdateComment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommend>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommentHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCommentCommend request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<CommentEntity>(request);

            await _unitOfWork.comments.UpdateAsync(post);
        }
    }
}
