using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Interfaces;
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
        private readonly IPostRepository _postRepository;

        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Handle(DeletePostCommend request, CancellationToken cancellationToken)
        {
            var post =  await _postRepository.GetByIdAsync(request.Id);

            await _postRepository.DeleteAsync(post);
        }
    }
}
