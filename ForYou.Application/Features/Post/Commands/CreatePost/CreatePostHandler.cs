using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Command.Post.CreatePost;
using ForYou.Application.Interfaces;
using ForYou.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatePostValidator = ForYou.Application.Command.Post.CreatePostValidator;

namespace ForYou.Application.Handler.Post
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommend, Guid>
    {
        private readonly IMapper _mapper;

        private readonly IPostRepository _postRepository;

        public CreatePostHandler(IPostRepository postRepository,IMapper mapper) {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePostCommend request, CancellationToken cancellationToken)
        {
            PostEntity post = _mapper.Map<PostEntity>(request);

            CreatePostValidator validator = new CreatePostValidator();

            var result = await validator.ValidateAsync(request);

            if(result.Errors.Any()) throw new Exception("post not found");
 
            await _postRepository.AddAsync(post);

            return post.Id;

        }

    }
}
