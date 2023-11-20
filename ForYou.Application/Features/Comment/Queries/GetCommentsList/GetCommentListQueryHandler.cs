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

namespace ForYou.Application.Features.Comment.Queries.GetCommentsList
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, GetCommentListQueryViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public GetCommentListQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public  async Task<GetCommentListQueryViewModel> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
           var comments =  await _commentRepository.GetAllAsync();
            return _mapper.Map<GetCommentListQueryViewModel>(comments);
        }
    }
}
