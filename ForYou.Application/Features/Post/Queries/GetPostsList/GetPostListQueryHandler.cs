using AutoMapper;
using ForYou.Application.Features.Post.Queries.GetPostsList;
using ForYou.Application.Interfaces;
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
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostListQueryHandler(IPostRepository postRepository,IMapper mapper) {

            _mapper = mapper;
            _postRepository = postRepository;
        }


        public async Task<List<GetPostListQueryViewModel>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllAsync();
            return _mapper.Map<List<GetPostListQueryViewModel>>(allPosts);
        }
    }
}
