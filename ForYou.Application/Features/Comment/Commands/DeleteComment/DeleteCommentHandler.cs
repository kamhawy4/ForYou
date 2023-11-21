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
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(DeleteCommentCommend request, CancellationToken cancellationToken)
        {
            var post = await _commentRepository.GetByIdAsync(request.Id);

            await _commentRepository.DeleteAsync(post);

        }
    }
}
