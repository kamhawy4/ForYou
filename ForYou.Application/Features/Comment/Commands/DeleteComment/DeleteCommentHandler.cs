using AutoMapper;
using ForYou.Application.Command.Commands.DeleteComment;
using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Handler.Post
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommend>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCommentCommend request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.comments.GetByIdAsync(request.Id);

            await _unitOfWork.comments.DeleteAsync(post);

        }
    }
}
