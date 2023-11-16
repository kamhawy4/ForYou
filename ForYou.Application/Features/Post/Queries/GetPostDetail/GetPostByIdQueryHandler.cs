using AutoMapper;
using ForYou.Application.Interfaces;
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

        private readonly IPostRepository _postRepository;  

        public GetPostByIdQueryHandler(IPostRepository postRepository, IMapper mapper) {

            _mapper = mapper;

            _postRepository = postRepository;

        }

        public async Task<GetPostByIdQueryViewModel> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);

            return _mapper.Map<GetPostByIdQueryViewModel>(post);
        }
    }
}
