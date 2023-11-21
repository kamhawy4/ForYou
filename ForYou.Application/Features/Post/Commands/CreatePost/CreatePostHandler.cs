using System.Net.Mail;
using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Interfaces;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Interfaces;
using MediatR;
using CreatePostValidator = ForYou.Application.Command.Post.CreatePostValidator;

namespace ForYou.Application.Handler.Post
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommend, Guid>
    {

        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IHandleAttachment _attachment;

        public CreatePostHandler(IPostRepository postRepository,IMapper mapper, IHandleAttachment attachment) {
            _postRepository = postRepository;
            _mapper = mapper;
            _attachment = attachment;
        }

        public async Task<Guid> Handle(CreatePostCommend request, CancellationToken cancellationToken)
        {
            PostEntity post = _mapper.Map<PostEntity>(request);

            CreatePostValidator validator = new CreatePostValidator();

            var result = await validator.ValidateAsync(request);

           // await _attachment.Upload(post.Image);

            if (result.Errors.Any()) throw new Exception("post not found");
 
            await _postRepository.AddAsync(post);

            return post.Id;

        }

    }
}
