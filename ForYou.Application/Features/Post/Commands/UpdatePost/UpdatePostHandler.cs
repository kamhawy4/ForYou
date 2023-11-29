using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Features.Category.Commands.UpdateCategory;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Handler.Post
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommend>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePostHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        

        public async Task Handle(UpdatePostCommend request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.posts.GetByIdAsync(request.Id);

            post.Title = request.Title;
            post.Content = request.Content;
            post.Image = request.Image;

            await _unitOfWork.posts.UpdateAsync(post);

        }

    }
}
