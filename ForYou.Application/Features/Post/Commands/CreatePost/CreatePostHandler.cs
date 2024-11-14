using System.Net.Mail;
using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using CreatePostValidator = ForYou.Application.Command.Post.CreatePostValidator;

namespace ForYou.Application.Handler.Post
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommend, Guid>
    {

        private readonly IMapper _mapper;
        private readonly IHandleAttachment _attachment;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostHandler(IMapper mapper, IHandleAttachment attachment, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _attachment = attachment;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePostCommend request, CancellationToken cancellationToken)
        {
            PostEntity post = _mapper.Map<PostEntity>(request);

            CreatePostValidator validator = new CreatePostValidator();

            var result = await validator.ValidateAsync( request);

             await _attachment.Upload(post.Image);

            if (result.Errors.Any()) throw new Exception("post not found");


            // Associate the tags with the post
            post.PostTag = request.TagIds.Select(tagId => new PostTagEntity
            {
                PostId = post.PostId,
                TagId = tagId
            }).ToList();

            await _unitOfWork.posts.AddAsync(post);

            return post.PostId;

        }

    }
}
