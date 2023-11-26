using AutoMapper;
using ForYou.Application.Features.Post.Queries.GetPostsList;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Post.Queries.GetPostDetail
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, List<GetPostListQueryViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPostListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<List<GetPostListQueryViewModel>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _unitOfWork.posts.GetAllAsync();
            return _mapper.Map<List<GetPostListQueryViewModel>>(allPosts);
        }
    }
}
