using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Interfaces;
using ForYou.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Handler.Post
{
    //public class UpdatePostHandler : IRequestHandler<UpdatePostCommend>
    //{

    //    private readonly IMapper _mapper;

    //    private readonly IPostRepository _postRepository;

    //    public UpdatePostHandler(IPostRepository postRepository, IMapper mapper)
    //    {
    //        _postRepository = postRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task Handle(UpdatePostCommend request, CancellationToken cancellationToken)
    //    {
    //        var post =  _mapper.Map<PostEntity>(request);

    //        await _postRepository.UpdateAsync(post);
    //    }
    //}
}
