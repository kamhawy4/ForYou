using AutoMapper;
using ForYou.Application.Contracts;
using ForYou.Application.Features.Post.Queries.GetPostDetail;
using ForYou.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Comment.Queries.GetCommentsDetail
{  
        public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryViewModel>
        {
            private readonly IMapper _mapper;
            private readonly ICommentRepository _commentRepository;

            public GetCommentByIdQueryHandler(ICommentRepository commentRepository, IMapper mapper)
            {
                _mapper = mapper;
                _commentRepository = commentRepository;
            }

            public async Task<GetCommentByIdQueryViewModel> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
            {
                var post = await _commentRepository.GetByIdAsync(request.Id);

                return _mapper.Map<GetCommentByIdQueryViewModel>(post);
            }
        
        }
}
