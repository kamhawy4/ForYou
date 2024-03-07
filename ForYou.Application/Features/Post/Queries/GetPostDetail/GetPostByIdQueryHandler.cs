using AutoMapper;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.SharedServices.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Post.Queries.GetPostDetail
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetPostByIdQueryViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResourceHandler _resourceHandler;

        public GetPostByIdQueryHandler(IMapper mapper,IResourceHandler resourceHandler, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            this._resourceHandler = resourceHandler;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetPostByIdQueryViewModel> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {

            var post = await _unitOfWork.posts.GetByIdAsync(request.Id);

            if (post == null)
               throw new Exception(_resourceHandler.GetError("PostNotFound"));

            return _mapper.Map<GetPostByIdQueryViewModel>(post);
        }
    }
}
