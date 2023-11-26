using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Handler.Post
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommend>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeletePostHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePostCommend request, CancellationToken cancellationToken)
        {
            var post =  await _unitOfWork.posts.GetByIdAsync(request.Id);

            await _unitOfWork.posts.DeleteAsync(post);
        }
    }
}
