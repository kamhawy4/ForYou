using AutoMapper;
using ForYou.Application.Command.Commands.UpdateComment;
using ForYou.Application.Command.Post;
using ForYou.Application.Contracts;
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
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task Handle(UpdateCommentCommend request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<CommentEntity>(request);

            await _commentRepository.UpdateAsync(post);
        }
    }
}
