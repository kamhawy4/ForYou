using AutoMapper;
using ForYou.Application.Command.Commands.UpdateComment;
using ForYou.Domain.Contracts;
using MediatR;

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
            var comments = await _unitOfWork.comments.GetByIdAsync(request.Id);

            comments.Comment = request.Comment;

            await _unitOfWork.comments.UpdateAsync(comments);

        }
    }
}
